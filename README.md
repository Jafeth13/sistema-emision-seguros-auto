# Sistema Emisión de Seguros Auto

API REST desarrollada en ASP.NET Core 8 para la emisión de pólizas de seguros de automóvil.

## Tecnologías Utilizadas

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server
- Swagger / OpenAPI
- Patrón Repository
- Arquitectura Controller - Service - Repository

## Funcionalidades

### Clientes

- GET /api/clientes
- GET /api/clientes/{id}
- POST /api/clientes

### Coberturas

- GET /api/coberturas
- GET /api/coberturas/{id}
- POST /api/coberturas
- PUT /api/coberturas/{id}
- DELETE /api/coberturas/{id}

### Pólizas

- POST /api/polizas/emitir
- GET /api/polizas
- GET /api/polizas/{id}

## Regla de Negocio

La PrimaTotal de la póliza se calcula en el servidor como la suma de los montos de las coberturas seleccionadas.

## Modelo de Datos

### Clientes

- Id
- Nombre
- Identificacion
- Correo

### Vehiculos

- Id
- Placa
- Marca
- Modelo
- Anio
- ValorComercial

### Coberturas

- Id
- Nombre
- MontoCobertura

### Polizas

- Id
- NumeroPoliza
- ClienteId
- VehiculoId
- FechaEmision
- SumaAsegurada
- PrimaTotal

### PolizaCoberturas

Tabla intermedia para relacionar pólizas con coberturas.

## Configuración

Actualizar la cadena de conexión en:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SegurosAutoDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Base de Datos

El proyecto utiliza Entity Framework Core con migraciones.

Ejecutar:

```powershell
Update-Database
```

o

```powershell
dotnet ef database update
```

para crear la base de datos y las tablas.

## Ejecución

1. Clonar el repositorio.
2. Configurar la cadena de conexión.
3. Ejecutar las migraciones.
4. Ejecutar el proyecto.

```powershell
dotnet run
```

5. Abrir Swagger:

```text
https://localhost:xxxx/swagger
```

## Manejo de Errores

La API implementa:

- 201 Created
- 400 Bad Request
- 404 Not Found
- 500 Internal Server Error

mediante middleware centralizado de excepciones.

## Autor

Jafeth Matamoros Cordero
