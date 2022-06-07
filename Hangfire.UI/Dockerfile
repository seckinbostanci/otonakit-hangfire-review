FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hangfire.UI/Hangfire.UI.csproj", "Hangfire.UI/"]
RUN dotnet restore "Hangfire.UI/Hangfire.UI.csproj"
COPY . .
WORKDIR "/src/Hangfire.UI"
RUN dotnet build "Hangfire.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire.UI.dll"]
