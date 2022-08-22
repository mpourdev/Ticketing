FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/", "src/"]
RUN dotnet restore "src/Endpoints/Ticketing.EndPoints.API/Ticketing.EndPoints.API.csproj"

RUN dotnet build "src/Endpoints/Ticketing.EndPoints.API/Ticketing.EndPoints.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "src/Endpoints/Ticketing.EndPoints.API/Ticketing.EndPoints.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ticketing.EndPoints.API.dll"]