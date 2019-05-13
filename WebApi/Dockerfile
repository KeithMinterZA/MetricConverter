FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebApi/MetricConverter.WebApi.csproj", "WebApi/"]
COPY ["MetricConversion.Library/MetricConverter.Library.csproj", "MetricConversion.Library/"]
RUN dotnet restore "WebApi/MetricConverter.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "MetricConverter.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MetricConverter.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MetricConverter.WebApi.dll"]