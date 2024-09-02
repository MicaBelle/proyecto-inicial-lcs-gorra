# Etapa base para la imagen
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de construcción para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Gorra.apiminimal.csproj", "Gorra.apiminimal/"]
RUN dotnet restore "Gorra.apiminimal/Gorra.apiminimal.csproj"
COPY . .
WORKDIR "/src/Gorra.apiminimal"
RUN dotnet build "Gorra.apiminimal.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Gorra.apiminimal.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final que se usará en producción
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gorra.apiminimal.dll"]