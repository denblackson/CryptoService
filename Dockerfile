# Buid stage 
from mcr.microsoft.com/dotnet/sdk:8.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./CryptoService/CryptoService.csproj" --disable-parallel
RUN dotnet publish "./CryptoService/CryptoService.csproj" -c release -o /app --no-restore

# Serve stage 
FROM mcr.microsoft.com/dotnet/aspnet:8.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000


ENTRYPOINT ["dotnet", "CryptoService.dll"]

# 