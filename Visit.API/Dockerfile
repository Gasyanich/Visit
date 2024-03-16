#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Visit.API/Visit.API.csproj", "Visit.API/"]
RUN dotnet restore "Visit.API/Visit.API.csproj"
COPY . .
WORKDIR "/src/Visit.API"
RUN dotnet build "Visit.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Visit.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Visit.API.dll"]