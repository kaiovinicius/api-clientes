FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["api_customer.grpc.services.address/api_customer.grpc.services.address.csproj", "api_customer.grpc.services.address/"]
COPY ["api_customer.domain.core/api_customer.domain.core.csproj", "api_customer.domain.core/"]
COPY ["api_customer.domain/api_customer.domain.csproj", "api_customer.domain/"]
COPY ["api_customer.cross.cutting.IOC/api_customer.cross.cutting.IOC.csproj", "api_customer.cross.cutting.IOC/"]
COPY ["api_customer.application/api_customer.application.csproj", "api_customer.application/"]
COPY ["api_customer.cross.cutting/api_customer.cross.cutting.csproj", "api_customer.cross.cutting/"]
COPY ["api_customer.application.DTO/api_customer.application.DTO.csproj", "api_customer.application.DTO/"]
COPY ["api_customer.application.Proto/api_customer.application.Proto.csproj", "api_customer.application.Proto/"]
COPY ["api_customer.services/api_customer.services.csproj", "api_customer.services/"]
COPY ["api_customer.repository/api_customer.repository.csproj", "api_customer.repository/"]
COPY ["api_customer.data/api_customer.data.csproj", "api_customer.data/"]
RUN dotnet restore "api_customer.grpc.services.address/api_customer.grpc.services.address.csproj"
COPY . .
WORKDIR "/src/api_customer.grpc.services.address"
RUN dotnet build "api_customer.grpc.services.address.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_customer.grpc.services.address.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_customer.grpc.services.address.dll", "--server.urls", "http://0.0.0.0:80"]