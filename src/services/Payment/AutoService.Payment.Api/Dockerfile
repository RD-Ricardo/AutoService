#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/Payment/AutoService.Payment.Api/AutoService.Payment.Api.csproj", "src/services/Payment/AutoService.Payment.Api/"]
RUN dotnet restore "./src/services/Payment/AutoService.Payment.Api/./AutoService.Payment.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Payment/AutoService.Payment.Api"
RUN dotnet build "./AutoService.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AutoService.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoService.Payment.Api.dll"]