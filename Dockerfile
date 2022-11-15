# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
COPY . ./
RUN dotnet publish -c Release -o out
    
# Build runtime image

FROM mcr.microsoft.com/dotnet/runtime:6.0.11-jammy-amd64
RUN ln -sf /usr/share/dotnet/dotnet /usr/bin/dotnet

RUN apt-get update
RUN apt-get -y install ncurses-dev
RUN apt-get -y install libncurses5-dev libncursesw5-dev
RUN apt-get -y install  openssh-server

RUN mkdir /var/run/sshd
RUN echo 'root:PASSWORD' | chpasswd
RUN sed -i 's/PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN sed 's@session\s*required\s*pam_loginuid.so@session optional pam_loginuid.so@g' -i /etc/pam.d/sshd
EXPOSE 22

WORKDIR /app
COPY --from=build-env /app/out .
ENV TERM=xterm-256color
ENV LANG=en_US.UTF-8
CMD ["/usr/sbin/sshd", "-D"]