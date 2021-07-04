FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["FTask.Api/FTask.Api.csproj", "FTask.Api/"]
RUN dotnet restore "FTask.Api\FTask.Api.csproj"
COPY . .
WORKDIR "/src/FTask.Api"
RUN dotnet build "FTask.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FTask.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FTask.Api.dll"]
