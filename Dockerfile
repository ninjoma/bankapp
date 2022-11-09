# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
COPY . ./
RUN dotnet publish -c Release -o out
    
# Build runtime image
FROM dotnet-jammy-modified

RUN dpkg --add-architecture i386 && apt update
RUN apt-get -y install libncurses5:i386
RUN ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

WORKDIR /app
ENV TERM=XTERM
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "bankapp.dll"]
