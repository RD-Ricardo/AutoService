#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AutoService.Api/AutoService.Api.csproj", "src/AutoService.Api/"]
COPY ["src/AutoService.Application/AutoService.Application.csproj", "src/AutoService.Application/"]
COPY ["src/AutoService.Core/AutoService.Core.csproj", "src/AutoService.Core/"]
COPY ["src/AutoService.Domain/AutoService.Domain.csproj", "src/AutoService.Domain/"]
COPY ["src/AutoService.Infrastructure/AutoService.Infrastructure.csproj", "src/AutoService.Infrastructure/"]
RUN dotnet restore "./src/AutoService.Api/./AutoService.Api.csproj"
COPY . .
WORKDIR "/src/src/AutoService.Api"
RUN dotnet build "./AutoService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AutoService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoService.Api.dll"]
