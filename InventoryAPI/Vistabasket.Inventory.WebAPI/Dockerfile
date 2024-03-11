#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InventoryAPI/Vistabasket.Inventory.WebAPI/Vistabasket.Inventory.WebAPI.csproj", "InventoryAPI/Vistabasket.Inventory.WebAPI/"]
COPY ["InventoryAPI/Vistabasket.Inventory.Data/Vistabasket.Inventory.Data.csproj", "InventoryAPI/Vistabasket.Inventory.Data/"]
COPY ["Common/VistaBasket.Common.Repository/VistaBasket.Common.Repository.csproj", "Common/VistaBasket.Common.Repository/"]
COPY ["InventoryAPI/Vistabasket.Inventory.Service/Vistabasket.Inventory.Service.csproj", "InventoryAPI/Vistabasket.Inventory.Service/"]
RUN dotnet restore "./InventoryAPI/Vistabasket.Inventory.WebAPI/Vistabasket.Inventory.WebAPI.csproj"
COPY . .
WORKDIR "/src/InventoryAPI/Vistabasket.Inventory.WebAPI"
RUN dotnet build "./Vistabasket.Inventory.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Vistabasket.Inventory.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vistabasket.Inventory.WebAPI.dll"]