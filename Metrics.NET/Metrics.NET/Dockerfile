#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Metrics.NET/Metrics.NET.csproj", "Metrics.NET/"]
RUN dotnet restore "Metrics.NET/Metrics.NET.csproj"
COPY . .
WORKDIR "/src/Metrics.NET"
RUN dotnet build "Metrics.NET.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Metrics.NET.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Metrics.NET.dll"]