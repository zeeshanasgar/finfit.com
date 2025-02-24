# Use Microsoft's official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:4.8 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /src
COPY . .

# Restore NuGet packages
RUN nuget restore FinanceWithFarid.csproj

# Build the project
RUN msbuild FinanceWithFarid.csproj /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

# Copy build output to runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /src/bin/Release/ .
ENTRYPOINT ["FinanceWithFarid.exe"]
