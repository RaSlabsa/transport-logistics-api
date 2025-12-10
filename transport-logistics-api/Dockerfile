# 1. Етап збірки (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо .csproj файли всіх шарів
COPY ["transport-logistics-api/transport-logistics-api.csproj", "transport-logistics-api/"]
COPY ["TransportLogistics.Core/TransportLogistics.Core.csproj", "TransportLogistics.Core/"]
COPY ["TransportLogistics.Services/TransportLogistics.Services.csproj", "TransportLogistics.Services/"]
COPY ["TransportLogistics.Repositories/TransportLogistics.Repositories.csproj", "TransportLogistics.Repositories/"]

# Відновлюємо залежності
RUN dotnet restore "transport-logistics-api/transport-logistics-api.csproj"

# Копіюємо решту коду
COPY . .

# Збираємо проект
WORKDIR "/src/transport-logistics-api"
RUN dotnet build "transport-logistics-api.csproj" -c Release -o /app/build

# 2. Етап публікації
FROM build AS publish
RUN dotnet publish "transport-logistics-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 3. Фінальний образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "transport-logistics-api.dll"]