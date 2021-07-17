FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY FTask.Api/FTask.Api.xml /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FTask.Api/FTask.Api.csproj", "FTask.Api/"]
COPY ["FTask.AuthServices/FTask.AuthServices.csproj", "FTask.AuthServices/"]
COPY ["FTask.AuthDatabase/FTask.AuthDatabase.csproj", "FTask.AuthDatabase/"]
COPY ["FTask.Shared/FTask.Shared.csproj", "FTask.Shared/"]
COPY ["FTask.Services/FTask.Services.csproj", "FTask.Services/"]
COPY ["FTask.Database/FTask.Database.csproj", "FTask.Database/"]
RUN dotnet restore "FTask.Api/FTask.Api.csproj"
COPY . .
WORKDIR "/src/FTask.Api"
RUN dotnet build "FTask.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FTask.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FTask.Api.dll"]
