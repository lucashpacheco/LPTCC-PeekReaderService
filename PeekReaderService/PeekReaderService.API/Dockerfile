#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PeekReaderService.API/PeekReaderService.API.csproj", "PeekReaderService.API/"]
RUN dotnet restore "PeekReaderService.API/PeekReaderService.API.csproj"
COPY . .
WORKDIR "/src/PeekReaderService.API"
RUN dotnet build "PeekReaderService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PeekReaderService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PeekReaderService.API.dll"]