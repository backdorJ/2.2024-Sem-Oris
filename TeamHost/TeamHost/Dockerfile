FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TeamHost/TeamHost.csproj", "TeamHost/"]
RUN dotnet restore "TeamHost/TeamHost.csproj"
COPY . .
WORKDIR "/src/TeamHost"
RUN dotnet build "TeamHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamHost.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamHost.dll"]
