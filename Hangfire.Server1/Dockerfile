FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hangfire.Server1/Hangfire.Server1.csproj", "Hangfire.Server1/"]
RUN dotnet restore "Hangfire.Server1/Hangfire.Server1.csproj"
COPY . .
WORKDIR "/src/Hangfire.Server1"
RUN dotnet build "Hangfire.Server1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire.Server1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Hangfire.Server1/appsettings.json .
ENTRYPOINT ["dotnet", "Hangfire.Server1.dll"]
