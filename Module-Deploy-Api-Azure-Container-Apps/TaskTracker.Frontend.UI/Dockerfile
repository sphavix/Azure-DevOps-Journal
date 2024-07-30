FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

USER app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Module-Deploy-Api-Azure-Container-Apps/TaskTracker.Frontend.UI/TaskTracker.Frontend.UI.csproj", "Module-Deploy-Api-Azure-Container-Apps/TaskTracker.Frontend.UI/"]
RUN dotnet restore "Module-Deploy-Api-Azure-Container-Apps/TaskTracker.Frontend.UI/TaskTracker.Frontend.UI.csproj"
COPY . .
WORKDIR "/src/Module-Deploy-Api-Azure-Container-Apps/TaskTracker.Frontend.UI"
RUN dotnet build "TaskTracker.Frontend.UI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TaskTracker.Frontend.UI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskTracker.Frontend.UI.dll"]
