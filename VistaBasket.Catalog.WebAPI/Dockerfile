#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VistaBasket.Catalog.WebAPI/VistaBasket.Catalog.WebAPI.csproj", "VistaBasket.Catalog.WebAPI/"]
COPY ["VistaBasket.Catalog.Data/VistaBasket.Catalog.Data.csproj", "VistaBasket.Catalog.Data/"]
COPY ["VistaBasket.Catalog.Entities/VistaBasket.Catalog.Entities.csproj", "VistaBasket.Catalog.Entities/"]
COPY ["VistaBasket.Catalog.Repository/VistaBasket.Catalog.Repository.csproj", "VistaBasket.Catalog.Repository/"]
COPY ["VistaBasket.Catalog.Service/VistaBasket.Catalog.Service.csproj", "VistaBasket.Catalog.Service/"]
RUN dotnet restore "./VistaBasket.Catalog.WebAPI/VistaBasket.Catalog.WebAPI.csproj"
COPY . .
WORKDIR "/src/VistaBasket.Catalog.WebAPI"
RUN dotnet build "./VistaBasket.Catalog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VistaBasket.Catalog.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VistaBasket.Catalog.WebAPI.dll"]