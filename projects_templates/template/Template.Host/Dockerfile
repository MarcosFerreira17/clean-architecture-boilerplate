#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Template
COPY ["./Template.Host/Template.Host.csproj", "./Template.Host/"]
COPY ["./Template.Application/Template.Application.csproj", "./Template.Application/"]
COPY ["./Template.Domain/Template.Domain.csproj", "./Template.Domain/"]
COPY ["./Template.Infraestructure/Template.Infraestructure.csproj", "./Template.Infraestructure/"]
RUN dotnet restore "./Template.Host/Template.Host.csproj"
COPY . .
#Deve ser modificado: 
WORKDIR "/Template/Template.Host" 
RUN dotnet build "Template.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Host.dll"]