# Строим приложение
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Копируем файл .csproj и восстанавливаем зависимости
COPY ["TestTaskSurveys.csproj", "./"]
RUN dotnet restore "./TestTaskSurveys.csproj"

# Копируем все файлы проекта
COPY . .

# Сборка проекта
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Стартовое окружение
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Копируем собранное приложение
COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "TestTaskSurveys.dll"]
