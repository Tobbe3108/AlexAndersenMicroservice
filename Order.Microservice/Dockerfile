#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Order.Microservice/Order.Microservice.csproj", "Order.Microservice/"]
COPY ["Order.Microservice.Tests.Unit/Order.Microservice.Tests.Unit.csproj", "Order.Microservice.Tests.Unit/"]
RUN dotnet restore "Order.Microservice/Order.Microservice.csproj"
RUN dotnet restore "Order.Microservice.Tests.Unit/Order.Microservice.Tests.Umit.csproj"
COPY . .
WORKDIR "/src/Order.Microservice"
RUN dotnet build "Order.Microservice.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS test  
COPY --from=build . .  
RUN dotnet test "MyApiTest/MyApiTest.csproj"

FROM build AS publish
RUN dotnet publish "Order.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Microservice.dll"]