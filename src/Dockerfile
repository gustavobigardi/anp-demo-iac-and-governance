#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["services/DevSquad.Services.API/DevSquad.Services.API.csproj", "services/DevSquad.Services.API/"]
RUN dotnet restore "services/DevSquad.Services.API/DevSquad.Services.API.csproj"
COPY . .
WORKDIR "/src/services/DevSquad.Services.API"
RUN dotnet build "DevSquad.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevSquad.Services.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevSquad.Services.API.dll"]