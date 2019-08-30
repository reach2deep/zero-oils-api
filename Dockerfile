FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Verdant.Zero.Erp.Api/Verdant.Zero.Erp.Api.csproj", "Verdant.Zero.Erp.Api/"]
RUN dotnet restore "Verdant.Zero.Erp.Api/Verdant.Zero.Erp.Api.csproj"
COPY . .
WORKDIR "/src/Verdant.Zero.Erp.Api"
RUN dotnet build "Verdant.Zero.Erp.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Verdant.Zero.Erp.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Verdant.Zero.Erp.Api.dll"]