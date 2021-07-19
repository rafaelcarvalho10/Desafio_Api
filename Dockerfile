FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers

COPY ./src .
RUN dotnet restore

# Copy everything else and build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as base

# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
    libgdiplus \
    && rm -rf /var/lib/apt/lists/*

EXPOSE 9001
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Desafio.Api.Host.dll"]