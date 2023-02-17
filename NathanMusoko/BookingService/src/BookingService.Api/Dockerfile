FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5184
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:5184

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BookingService.Api/BookingService.Api.csproj", "src/BookingService.Api/"]
RUN dotnet restore "src/BookingService.Api/BookingService.Api.csproj"
COPY . .
WORKDIR "/src/src/BookingService.Api/"
RUN dotnet build "BookingService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingService.Api.dll"]
