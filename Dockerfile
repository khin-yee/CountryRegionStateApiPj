# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /

# Copy project files and restore dependencies
COPY ["CountryRegion/CountryRegion.csproj", "CountryRegion/"]
COPY ["CountryRegion.Domain/CountryRegion.Domain.csproj", "CountryRegion.Domain/"]
COPY ["CountryRegion.Repository/CountryRegion.Repository.csproj", "CountryRegion.Repository/"]
COPY ["CountryRegion.Service/CountryRegion.Service.csproj", "CountryRegion.Service/"]


RUN dotnet restore "CountryRegion/CountryRegion.csproj"

# Copy the rest of the code and build the application
COPY . .
WORKDIR "CountryRegion"
RUN dotnet build "CountryRegion.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "CountryRegion.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountryRegion.dll"]
