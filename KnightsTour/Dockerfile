FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["KnightsTour/KnightsTour.csproj", "KnightsTour/"]
RUN dotnet restore "KnightsTour/KnightsTour.csproj"
COPY . .
WORKDIR "/src/KnightsTour"
RUN dotnet build "KnightsTour.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KnightsTour.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KnightsTour.dll"]
