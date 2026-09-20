FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["APIEstudiantes.csproj", "./"]
RUN dotnet restore "APIEstudiantes.csproj"

COPY . .
RUN dotnet publish "APIEstudiantes.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "APIEstudiantes.dll"]