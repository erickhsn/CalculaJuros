#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CalculaJuros/CalculaJuros.API.csproj", "CalculaJuros/"]
RUN dotnet restore "CalculaJuros/CalculaJuros.API.csproj"
COPY . .
WORKDIR "/src/CalculaJuros"
RUN dotnet build "CalculaJuros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.API.dll"]