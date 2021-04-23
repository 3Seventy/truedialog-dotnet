#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TrueDialog.Client.Standard.WebTests/TrueDialog.Client.Standard.WebTests.csproj", "TrueDialog.Client.Standard.WebTests/"]
RUN dotnet restore "TrueDialog.Client.Standard.WebTests/TrueDialog.Client.Standard.WebTests.csproj"
COPY . .
WORKDIR "/src/TrueDialog.Client.Standard.WebTests"
RUN dotnet build "TrueDialog.Client.Standard.WebTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrueDialog.Client.Standard.WebTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrueDialog.Client.Standard.WebTests.dll"]