#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Template
COPY ["./Template.Presentation/Template.Presentation.csproj", "./Template.Presentation/"]
COPY ["./Template.Application/Template.Application.csproj", "./Template.Application/"]
COPY ["./Template.Domain/Template.Domain.csproj", "./Template.Domain/"]
COPY ["./Template.Infrastructure/Template.Infrastructure.csproj", "./Template.Infrastructure/"]
RUN dotnet restore "./Template.Presentation/Template.Presentation.csproj"
COPY . .
#Deve ser modificado: 
WORKDIR "/Template/Template.Presentation" 
RUN dotnet build "Template.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Presentation.dll"]