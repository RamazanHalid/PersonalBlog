#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /appp

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BlogMVC/BlogMVC.csproj", "BlogMVC/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore
COPY . ./ 
 
 
RUN dotnet publish --no-restore -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /appp
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BlogMVC.dll"]