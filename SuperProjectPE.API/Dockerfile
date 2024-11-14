FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SuperProjectPE.API/SuperProjectPE.API.csproj", "SuperProjectPE.API/"]
COPY ["SuperProjectPE.REPO/SuperProjectPE.REPO.csproj", "SuperProjectPE.REPO/"]
COPY ["SuperProjectPE.DAO/SuperProjectPE.DAO.csproj", "SuperProjectPE.DAO/"]
COPY ["SuperProjectPE.BO/SuperProjectPE.BO.csproj", "SuperProjectPE.BO/"]
RUN dotnet restore "SuperProjectPE.API/SuperProjectPE.API.csproj"
COPY . .
WORKDIR "/src/SuperProjectPE.API"
RUN dotnet build "SuperProjectPE.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SuperProjectPE.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuperProjectPE.API.dll"]
