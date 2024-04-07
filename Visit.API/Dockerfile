FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Visit.API/Visit.API.csproj", "Visit.API/"]
COPY ["Visit.DAL/Visit.DAL.csproj", "Visit.DAL/"]
COPY ["Visit.Domain/Visit.Domain.csproj", "Visit.Domain/"]
COPY ["Visit.Domain.BL/Visit.Domain.BL.csproj", "Visit.Domain.BL/"]
COPY ["Visit.Contracts/Visit.Contracts.csproj", "Visit.Contracts/"]
RUN dotnet restore "Visit.API/Visit.API.csproj"
COPY . .
WORKDIR "/src/Visit.API"
RUN dotnet build "Visit.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Visit.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Visit.API.dll"]
