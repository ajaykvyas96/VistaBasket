#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VistaBasket.Auth.WebAPI/VistaBasket.Auth.WebAPI.csproj", "VistaBasket.Auth.WebAPI/"]
COPY ["VistaBasket.Auth.Data/VistaBasket.Auth.Data.csproj", "VistaBasket.Auth.Data/"]
COPY ["VistaBasket.Auth.Entities/VistaBasket.Auth.Entities.csproj", "VistaBasket.Auth.Entities/"]
COPY ["VistaBasket.Auth.Repository/VistaBasket.Auth.Repository.csproj", "VistaBasket.Auth.Repository/"]
COPY ["VistaBasket.Auth.Service/VistaBasket.Auth.Service.csproj", "VistaBasket.Auth.Service/"]
COPY ["VistaBasket.MessageBus/VistaBasket.MessageBus.csproj", "VistaBasket.MessageBus/"]
RUN dotnet restore "./VistaBasket.Auth.WebAPI/VistaBasket.Auth.WebAPI.csproj"
COPY . .
WORKDIR "/src/VistaBasket.Auth.WebAPI"
RUN dotnet build "./VistaBasket.Auth.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VistaBasket.Auth.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VistaBasket.Auth.WebAPI.dll"]