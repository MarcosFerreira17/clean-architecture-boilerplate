#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["External/Template.Presentation/Template.Presentation.csproj", "External/Template.Presentation/"]
COPY ["Core/Template.Application/Template.Application.csproj", "Core/Template.Application/"]
COPY ["External/Template.Infrastructure/Template.Infrastructure.csproj", "External/Template.Infrastructure/"]
COPY ["Core/Template.Domain/Template.Domain.csproj", "Core/Template.Domain/"]
RUN dotnet restore "External/Template.Presentation/Template.Presentation.csproj"
COPY . .
WORKDIR "/src/External/Template.Presentation"
RUN dotnet build "Template.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Presentation.dll"]