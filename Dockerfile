# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
COPY . ./
RUN dotnet publish -c Release -o out
    
# Build runtime image
FROM dotnet-jammy-modified
WORKDIR /app
ENV TERM=XTERM
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "bankapp.dll"]