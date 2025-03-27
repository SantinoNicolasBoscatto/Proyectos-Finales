# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Presentation/PruebaMicroservicios.Autor.Presentation.csproj", "src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Presentation/"]
COPY ["src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Application/PruebaMicroservicios.Autor.Application.csproj", "src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Application/"]
COPY ["src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Domain/PruebaMicroservicios.Autor.Domain.csproj", "src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Domain/"]
COPY ["src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Infrastructure/PruebaMicroservicios.Autor.Infrastructure.csproj", "src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Infrastructure/"]
RUN dotnet restore "./src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Presentation/PruebaMicroservicios.Autor.Presentation.csproj"
COPY . .
WORKDIR "/src/src/PruebaMicroservicios.Autor/PruebaMicroservicios.Autor.Presentation"
RUN dotnet build "./PruebaMicroservicios.Autor.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PruebaMicroservicios.Autor.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#COPY ./gRPCcert.pfx /app/gRPCcert.pfx

# Configura las variables de entorno para HTTPS en el puerto 8080
ENV ASPNETCORE_URLS="https://+:8080"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/gRPCcert.pfx"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Password="my-secret"

ENTRYPOINT ["dotnet", "PruebaMicroservicios.Autor.Presentation.dll"]