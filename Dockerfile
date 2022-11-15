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



WORKDIR /app
COPY --from=build-env /app/out .
ENV TERM=xterm-256color
ENV LANG=en_US.UTF-8
ENTRYPOINT ["dotnet", "bankapp.dll"]
