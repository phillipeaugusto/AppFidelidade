FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AppFidelidade.API/AppFidelidade.API.csproj", "AppFidelidade.API/"]
RUN dotnet restore "AppFidelidade.API/AppFidelidade.API.csproj"
COPY . .
WORKDIR "/src/AppFidelidade.API"
RUN dotnet build "AppFidelidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppFidelidade.API.csproj" -c Release -o out
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/AppFidelidade.API.dll