FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomValidation.Api/CustomValidation.Api.csproj", "CustomValidation.Api/"]
RUN dotnet restore "CustomValidation.Api/CustomValidation.Api.csproj"
COPY . .
WORKDIR "/src/CustomValidation.Api"
RUN dotnet build "CustomValidation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomValidation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomValidation.Api.dll"]
