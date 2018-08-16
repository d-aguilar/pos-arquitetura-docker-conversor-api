FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Pos.Conversor.API/Pos.Conversor.API.csproj Pos.Conversor.API/
RUN dotnet restore Pos.Conversor.API/Pos.Conversor.API.csproj
COPY . .
WORKDIR /src/Pos.Conversor.API
RUN dotnet build Pos.Conversor.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Pos.Conversor.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pos.Conversor.API.dll"]
