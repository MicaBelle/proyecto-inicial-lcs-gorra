# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copia el certificado al contenedor
COPY aspnetcore-selfsigned.crt /https/aspnetcore-selfsigned.crt
COPY aspnetcore-selfsigned.key /https/aspnetcore-selfsigned.key

# Configura ASP.NET Core para usar el certificado SSL
ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetcore-selfsigned.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/https/aspnetcore-selfsigned.key

EXPOSE 80
EXPOSE 443

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Gorra.apiminimal.csproj", "Gorra.apiminimal/"]
RUN dotnet restore "./Gorra.apiminimal/Gorra.apiminimal.csproj"
COPY . .
WORKDIR "/src/Gorra.apiminimal"
RUN dotnet build "./Gorra.apiminimal.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Gorra.apiminimal.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gorra.apiminimal.dll"]