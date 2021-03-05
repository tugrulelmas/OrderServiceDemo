FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Order.CreateService/Order.CreateService.csproj", "Order.CreateService/"]
RUN dotnet restore "Order.CreateService/Order.CreateService.csproj"
COPY . .
WORKDIR "/src/Order.CreateService"
RUN dotnet build "Order.CreateService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.CreateService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.CreateService.dll"]