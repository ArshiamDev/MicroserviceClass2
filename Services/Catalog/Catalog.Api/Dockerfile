FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Catalog.Api.csproj", "./"]
RUN dotnet restore "Catalog.Api.csproj"

COPY . .
RUN dotnet build "Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]
