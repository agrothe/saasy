FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5432

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SaaSy.Web/SaaSy.Web.csproj", "SaaSy.Web/"]
RUN dotnet restore "SaaSy.Web/SaaSy.Web.csproj"
COPY . .
WORKDIR "/src/SaaSy.Web"
RUN dotnet build "SaaSy.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SaaSy.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SaaSy.Web.dll"]