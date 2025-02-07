# Используем базовый образ для .NET SDK 8.0 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

ARG BUILD_CONFIGURATION
RUN echo ${BUILD_CONFIGURATION}

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем solution файл
COPY ../LibraryService/LibraryService.sln ./LibraryService/
COPY ../Common/Common.sln ./Common/

# Копируем все проекты
COPY ../LibraryService/ ./LibraryService/
COPY ../Common/ ./Common/

# Восстанавливаем зависимости (включая проекты из разных директорий)
RUN dotnet restore ./LibraryService/src/LibraryService.API/LibraryService.API.csproj

# Собираем проект
RUN dotnet publish ./LibraryService/src/LibraryService.API/LibraryService.API.csproj -c "$BUILD_CONFIGURATION" -o /app/out

# Используем минимальный runtime-образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build-env /app/out .

# Задаем команду запуска приложения
ENTRYPOINT ["dotnet", "LibraryService.API.dll"]