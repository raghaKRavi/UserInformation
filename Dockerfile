## Use the official .NET Core runtime as the base image
#FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
#WORKDIR /app
## Use the official .NET Core SDK as the build image
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#
#WORKDIR /src
#
#COPY ["./src/UserInfo/UserInfo.csproj", "./"]
#
#RUN dotnet restore "./UserInfo.csproj"
#
#COPY . .
#
#WORKDIR "/src/"
#
#RUN dotnet build -c Release -o /app/build
#
#FROM build AS publish
#
#RUN dotnet publish -c Release -o /app/publish
#
## Build the final image using the base image and the published output
##FROM base AS final
##
##WORKDIR /app
##COPY --from=publish /app/publish .
#
#EXPOSE 8080
#
#ENTRYPOINT ["dotnet", "/app/publish/UserInfo.dll"]

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY ./src/UserInfo/*.csproj ./
RUN dotnet restore

# Copy the rest of the application and build it
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the build output
COPY --from=build /app/publish ./

# Expose the application's default port (e.g., 80)
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "UserInfo.dll"]

