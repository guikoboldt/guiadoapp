#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Guiado.Service/Guiado.API.csproj", "Guiado.Service/"]
COPY ["Guiado.Infrastructure/Guiado.Infrastructure.csproj", "Guiado.Infrastructure/"]
COPY ["Guiado.Domain/Guiado.Domain.csproj", "Guiado.Domain/"]
RUN dotnet restore "Guiado.Service/Guiado.API.csproj"
COPY . .
WORKDIR "/src/Guiado.Service"
RUN dotnet build "Guiado.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Guiado.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Guiado.API.dll"]