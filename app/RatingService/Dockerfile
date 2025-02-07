# Используем базовый образ для .NET SDK 8.0 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

ARG BUILD_CONFIGURATION
RUN echo ${BUILD_CONFIGURATION}

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем solution файл
COPY ../RatingService/RatingService.sln ./RatingService/
COPY ../Common/Common.sln ./Common/

# Копируем все проекты
COPY ../RatingService/ ./RatingService/
COPY ../Common/ ./Common/

# Восстанавливаем зависимости (включая проекты из разных директорий)
RUN dotnet restore ./RatingService/src/RatingService.API/RatingService.API.csproj

# Собираем проект
RUN dotnet publish ./RatingService/src/RatingService.API/RatingService.API.csproj -c "$BUILD_CONFIGURATION" -o /app/out

# Используем минимальный runtime-образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build-env /app/out .

# Задаем команду запуска приложения
ENTRYPOINT ["dotnet", "RatingService.API.dll"]