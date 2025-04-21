FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Infrastructure/microservices_eShopping.Identity/microservices_eShopping.Identity.csproj", "Infrastructure/microservices_eShopping.Identity/"]
RUN dotnet restore "Infrastructure/microservices_eShopping.Identity/microservices_eShopping.Identity.csproj"
COPY . .
WORKDIR "/src/Infrastructure/microservices_eShopping.Identity"
RUN dotnet build "microservices_eShopping.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "microservices_eShopping.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "microservices_eShopping.Identity.dll"]
