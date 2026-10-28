# Sistema Emisión de Seguros Auto

API REST desarrollada en ASP.NET Core 8 para la gestión y emisión de pólizas de seguros de automóvil.

La solución fue desarrollada utilizando una arquitectura por capas y separación física de responsabilidades mediante proyectos independientes para la API, Aplicación, Dominio e Infraestructura.

---

# Tecnologías Utilizadas

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server
- Swagger / OpenAPI
- Dependency Injection
- Repository Pattern
- Middleware Global de Excepciones
- Arquitectura por Capas

---

# Arquitectura de la Solución

La solución está organizada en cuatro proyectos:

## SistemaEmisionSegurosAuto.API

Contiene la capa de presentación.

- Controllers
- Middleware
- Program.cs
- appsettings.json
- Configuración de Swagger

## SistemaEmisionSegurosAuto.Aplicacion

Contiene la lógica de aplicación.

- DTOs
- Interfaces
- Servicios
- Excepciones de negocio

## SistemaEmisionSegurosAuto.Dominio

Contiene las entidades del dominio.

- Cliente
- Vehiculo
- Cobertura
- Poliza
- PolizaCobertura

## SistemaEmisionSegurosAuto.Infraestructura

Contiene la implementación del acceso a datos.

- ApplicationDbContext
- Repositorios
- Migraciones
- Configuración de Entity Framework Core
- Dependency Injection

---

# Modelo de Datos

## Clientes

- Id
- Nombre
- Identificacion
- Correo

## Vehiculos

- Id
- Placa
- Marca
- Modelo
- Anio
- ValorComercial

## Coberturas

- Id
- Nombre
- MontoCobertura
- Activo

## Polizas

- Id
- NumeroPoliza
- ClienteId
- VehiculoId
- FechaEmision
- SumaAsegurada
- PrimaTotal

## PolizaCoberturas

Tabla de relación entre pólizas y coberturas.

- PolizaId
- CoberturaId

---

# Funcionalidades Implementadas

## Catálogo de Clientes

- Obtener clientes
- Obtener cliente por id
- Crear cliente

## Catálogo de Coberturas

- Obtener coberturas
- Obtener cobertura por id
- Crear cobertura
- Actualizar cobertura
- Eliminar cobertura (borrado lógico)

## Emisión de Pólizas

- Emisión de pólizas de automóvil
- Cálculo automático de PrimaTotal
- Generación automática de número de póliza
- Asociación de cliente, vehículo y coberturas
- Uso de transacciones para garantizar integridad de datos

## Consulta de Pólizas

- Consulta individual por id
- Historial completo de pólizas emitidas

---

# Reglas de Negocio

- El cliente debe existir para emitir una póliza.
- La póliza debe incluir al menos una cobertura.
- La PrimaTotal se calcula en el servidor sumando los montos de las coberturas seleccionadas.
- El número de póliza se genera automáticamente.
- La emisión utiliza transacciones para garantizar consistencia en los datos.
- Las coberturas utilizan borrado lógico para preservar la trazabilidad histórica de las pólizas emitidas.

---

# Endpoints

## Clientes

### Obtener todos los clientes

```http
GET /api/clientes
```

### Obtener cliente por id

```http
GET /api/clientes/{id}
```

### Crear cliente

```http
POST /api/clientes
```

Ejemplo:

```json
{
  "nombre": "Jafeth Matamoros",
  "identificacion": "305310870",
  "correo": "jafeth@test.com"
}
```

---

## Coberturas

### Obtener coberturas

```http
GET /api/coberturas
```

### Obtener cobertura por id

```http
GET /api/coberturas/{id}
```

### Crear cobertura

```http
POST /api/coberturas
```

Ejemplo:

```json
{
  "nombre": "Robo",
  "montoCobertura": 100
}
```

### Actualizar cobertura

```http
PUT /api/coberturas/{id}
```

### Eliminar cobertura

```http
DELETE /api/coberturas/{id}
```

> El endpoint realiza borrado lógico estableciendo el campo Activo en false.

---

## Pólizas

### Emitir póliza

```http
POST /api/polizas/emitir
```

Ejemplo:

```json
{
  "clienteId": 1,
  "vehiculo": {
    "placa": "ABC123",
    "marca": "Toyota",
    "modelo": "Corolla",
    "anio": 2022,
    "valorComercial": 15000
  },
  "coberturasIds": [1, 2, 3]
}
```

### Obtener historial de pólizas

```http
GET /api/polizas
```

### Obtener póliza por id

```http
GET /api/polizas/{id}
```

---

# Manejo de Errores

La aplicación implementa manejo centralizado de excepciones mediante middleware global.

## Códigos HTTP

### 201 Created

Recurso creado exitosamente.

### 400 Bad Request

Error de validación o regla de negocio.

Ejemplo:

```json
{
  "message": "Debe seleccionar al menos una cobertura"
}
```

### 404 Not Found

Recurso no encontrado.

Ejemplo:

```json
{
  "message": "Cliente no encontrado"
}
```

### 500 Internal Server Error

Error inesperado del servidor.

---

# Configuración de Base de Datos

Modificar la cadena de conexión en:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SegurosAutoDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

# Migraciones

Las migraciones de Entity Framework Core se encuentran incluidas en el proyecto:

```text
SistemaEmisionSegurosAuto.Infraestructura
└── Migrations
```

Para crear la base de datos ejecutar:

```powershell
Update-Database -Project SistemaEmisionSegurosAuto.Infraestructura -StartupProject SistemaEmisionSegurosAuto.API
```

---

# Ejecución del Proyecto

## 1. Clonar el repositorio

```bash
git clone https://github.com/Jafeth13/sistema-emision-seguros-auto.git
```

## 2. Configurar la cadena de conexión

Actualizar el archivo:

```text
appsettings.json
```

## 3. Ejecutar migraciones

```powershell
Update-Database -Project SistemaEmisionSegurosAuto.Infraestructura -StartupProject SistemaEmisionSegurosAuto.API
```

## 4. Ejecutar la API

Desde Visual Studio:

```text
F5
```

o

```bash
dotnet run
```

## 5. Abrir Swagger

```text
https://localhost:xxxx/swagger
```

---

# Características Técnicas

- Arquitectura por capas.
- Separación física por proyectos.
- Entity Framework Core.
- SQL Server.
- Repository Pattern.
- Dependency Injection.
- Middleware Global de Excepciones.
- Excepciones personalizadas.
- DTOs.
- Transacciones.
- Swagger.
- Borrado lógico de coberturas.
- Migraciones Code First.

---

# Autor

**Jafeth Matamoros Cordero**
