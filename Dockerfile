# syntax=docker/dockerfile:1

FROM node:24-alpine AS frontend
WORKDIR /src/frontend
COPY frontend/package.json frontend/package-lock.json ./
RUN npm ci
COPY frontend/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS backend
WORKDIR /src
COPY backend/Directory.Build.props backend/
COPY backend/HealthY.Api/HealthY.Api.csproj backend/HealthY.Api/
COPY backend/HealthY.Core/HealthY.Core.csproj backend/HealthY.Core/
COPY backend/HealthY.Infrastructure/HealthY.Infrastructure.csproj backend/HealthY.Infrastructure/
RUN dotnet restore backend/HealthY.Api/HealthY.Api.csproj
COPY backend/ backend/
RUN dotnet publish backend/HealthY.Api/HealthY.Api.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=backend /app ./
COPY --from=frontend /src/frontend/dist ./wwwroot
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
USER $APP_UID
ENTRYPOINT ["dotnet", "HealthY.Api.dll"]
