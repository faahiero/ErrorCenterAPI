FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ErrorCenter.csproj", "./"]
RUN dotnet restore "./ErrorCenter.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ErrorCenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ErrorCenter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet ErrorCenter.dll






















# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /app

# COPY *.csproj ./
# RUN dotnet restore

# COPY . ./
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app

# RUN useradd -m faahiero
# USER faahiero

# COPY --from=build-env /app/out .
# CMD ASPNETCORE_URLS="http://*:$PORT" dotnet ErrorCenter.dll
