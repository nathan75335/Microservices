FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app

EXPOSE 80
EXPOSE 5091

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/IdentityService.Api/IdentityService.Api.csproj", "src/IdentityService.Api/"]
RUN dotnet restore "src/IdentityService.Api/IdentityService.Api.csproj"
COPY . .
WORKDIR "/src/src/IdentityService.Api"
RUN dotnet build "IdentityService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.Api.dll"]
