# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Presentation/PruebaMicroservicios.Libro.Presentation.csproj", "src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Presentation/"]
COPY ["src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Application/PruebaMicroservicios.Libro.Application.csproj", "src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Application/"]
COPY ["src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Domain/PruebaMicroservicios.Libro.Domain.csproj", "src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Domain/"]
COPY ["src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Infrastructure/PruebaMicroservicios.Libro.Infrastructure.csproj", "src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Infrastructure/"]
RUN dotnet restore "./src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Presentation/PruebaMicroservicios.Libro.Presentation.csproj"
COPY . .
WORKDIR "/src/src/PruebaMicroservicios.Libro/PruebaMicroservicios.Libro.Presentation"
RUN dotnet build "./PruebaMicroservicios.Libro.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PruebaMicroservicios.Libro.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copia el certificado PFX al contenedor. (Asegúrate de que la ruta de origen sea correcta)
#COPY ./localhost.pfx /app/localhost.pfx
#
# Establece las variables de entorno para ejecutar la aplicación en HTTPS en el puerto 8081
ENV ASPNETCORE_URLS="https://+:8081"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/localhost.pfx"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Password="contraseña123"

ENTRYPOINT ["dotnet", "PruebaMicroservicios.Libro.Presentation.dll"]