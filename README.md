# API REST Concesionarias

Este proyecto contiene una estructura de ejemplo para crear una API REST "full" con **.NET 8** siguiendo una arquitectura exagonal. Se usan las siguientes entidades:

- **Concesionaria**
- **Sucursal** (pertenece a una concesionaria)

La API expone operaciones CRUD y está preparada para integrarse con **Swagger**.

## Estructura de carpetas

```
src/
  Apimaf.Domain/          # Entidades y contratos de dominio
  Apimaf.Application/     # DTOs y servicios de aplicación
  Apimaf.Infrastructure/  # Implementaciones (EF Core, repositorios)
  Apimaf.WebAPI/          # Proyecto Web API
```

## Pasos para ejecutar

1. Instalar el SDK de **.NET 8**.
2. Restaurar dependencias y compilar:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Revisar `src/Apimaf.WebAPI/appsettings.json` y ajustar la cadena de conexión si es necesario. Por defecto se usa un SQL Server en Azure.
4. Aplicar migraciones de Entity Framework Core (opcional según configuración):
   ```bash
   dotnet ef migrations add InitialCreate -p src/Apimaf.Infrastructure -s src/Apimaf.WebAPI
   dotnet ef database update -p src/Apimaf.Infrastructure -s src/Apimaf.WebAPI
   ```
5. Ejecutar la API:
   ```bash
   dotnet run --project src/Apimaf.WebAPI
   ```
6. Abrir `https://localhost:{puerto}/swagger` para ver la documentación generada por Swagger.

## Descripción rápida

La arquitectura se divide en varias capas:

- **Dominio**: define las entidades `Concesionaria` y `Sucursal`, además de las interfaces de repositorio.
- **Aplicación**: contiene los servicios que orquestan la lógica de negocio y exponen DTOs.
- **Infraestructura**: implementa los repositorios usando Entity Framework Core y define el `DbContext`.
- **WebAPI**: configura los controladores, la inyección de dependencias y Swagger.

Cada método posee comentarios `TODO` indicando su propósito principal.
