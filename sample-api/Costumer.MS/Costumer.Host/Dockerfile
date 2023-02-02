#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Costumer
COPY ["./Costumer.Host/Costumer.Host.csproj", "./Costumer.Host/"]
COPY ["./Costumer.Application/Costumer.Application.csproj", "./Costumer.Application/"]
COPY ["./Costumer.Domain/Costumer.Domain.csproj", "./Costumer.Domain/"]
COPY ["./Costumer.Infraestructure/Costumer.Infraestructure.csproj", "./Costumer.Infraestructure/"]
RUN dotnet restore "./Costumer.Host/Costumer.Host.csproj"
COPY . .
#Deve ser modificado: 
WORKDIR "/Costumer/Costumer.Host" 
RUN dotnet build "Costumer.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Costumer.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Costumer.Host.dll"]