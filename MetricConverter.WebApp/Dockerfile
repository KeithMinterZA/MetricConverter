FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MetricConverter.WebApp/MetricConverter.WebApp.csproj", "MetricConverter.WebApp/"]
COPY ["MetricConversion.Library/MetricConverter.Library.csproj", "MetricConversion.Library/"]
RUN dotnet restore "MetricConverter.WebApp/MetricConverter.WebApp.csproj"
COPY . .
WORKDIR "/src/MetricConverter.WebApp"
RUN dotnet build "MetricConverter.WebApp.csproj" -c Debug -o /app

FROM build AS publish
RUN dotnet publish "MetricConverter.WebApp.csproj" -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MetricConverter.WebApp.dll"]
