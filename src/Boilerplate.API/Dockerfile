#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Boilerplate.API/Boilerplate.API.csproj", "Boilerplate.API/"]
COPY ["Boilerplate.Application/Boilerplate.Application.csproj", "Boilerplate.Application/"]
COPY ["Boilerplate.Infra.Database/Boilerplate.Infra.Database.csproj", "Boilerplate.Infra.Database/"]
COPY ["Boilerplate.Domain/Boilerplate.Domain.csproj", "Boilerplate.Domain/"]
RUN dotnet restore "Boilerplate.API/Boilerplate.API.csproj"
COPY . .
WORKDIR "/src/Boilerplate.API"
RUN dotnet build "Boilerplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boilerplate.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boilerplate.API.dll"]