FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["api_clientes.grpc.services.cliente/api_clientes.grpc.services.cliente.csproj", "api_clientes.grpc.services.cliente/"]
COPY ["api_clientes.data/api_clientes.data.csproj", "api_clientes.data/"]
COPY ["api_clientes.domain/api_clientes.domain.csproj", "api_clientes.domain/"]
COPY ["api_clientes.cross.cutting.IOC/api_clientes.cross.cutting.IOC.csproj", "api_clientes.cross.cutting.IOC/"]
COPY ["api_clientes.application/api_clientes.application.csproj", "api_clientes.application/"]
COPY ["api_clientes.application.Proto/api_clientes.application.Proto.csproj", "api_clientes.application.Proto/"]
COPY ["api_clientes.cross.cutting/api_clientes.cross.cutting.csproj", "api_clientes.cross.cutting/"]
COPY ["api_clientes.application.DTO/api_clientes.application.DTO.csproj", "api_clientes.application.DTO/"]
COPY ["api_clientes.domain.core/api_clientes.domain.core.csproj", "api_clientes.domain.core/"]
COPY ["api_clientes.services/api_clientes.services.csproj", "api_clientes.services/"]
COPY ["api_clientes.repository/api_clientes.repository.csproj", "api_clientes.repository/"]
RUN dotnet restore "api_clientes.grpc.services.cliente/api_clientes.grpc.services.cliente.csproj"
COPY . .
WORKDIR "/src/api_clientes.grpc.services.cliente"
RUN dotnet build "api_clientes.grpc.services.cliente.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_clientes.grpc.services.cliente.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "api_clientes.grpc.services.cliente.dll"]