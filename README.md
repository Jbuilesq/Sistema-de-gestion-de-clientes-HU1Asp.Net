SISTEMA DE GESTIÓN DE CLIENTES - HU1 ASP.NET
=============================================

DESCRIPCIÓN GENERAL
-------------------
El Sistema de Gestión de Clientes es una API RESTful desarrollada con ASP.NET Core 8.0.
Su objetivo principal es administrar la información de clientes, productos y órdenes, proporcionando una interfaz de programación (API) robusta para realizar operaciones CRUD sobre cada módulo.

El sistema está diseñado con una arquitectura modular, donde cada recurso se gestiona mediante un controlador independiente, facilitando la escalabilidad y el mantenimiento del proyecto.

---------------------------------------------
ESTRUCTURA DEL PROYECTO
---------------------------------------------
management.Api/
│
├── Controllers/
│   ├── CustomerController.cs     → Controlador para operaciones de clientes
│   ├── ProductController.cs      → Controlador para operaciones de productos
│   └── OrderController.cs        → Controlador para operaciones de órdenes
│
├── Program.cs                    → Configuración e inicio de la aplicación
├── appsettings.json              → Configuración principal (puertos, conexiones, logging)
├── appsettings.Development.json  → Configuración para entorno de desarrollo
├── management.Api.csproj         → Archivo de configuración del proyecto .NET
└── Properties/
    └── launchSettings.json       → Configuración de ejecución local

---------------------------------------------
FUNCIONALIDADES IMPLEMENTADAS
---------------------------------------------

GESTIÓN DE CLIENTES
-------------------
Controlada por CustomerController.cs
- GET /api/customers           → Obtiene la lista completa de clientes.
- GET /api/customers/{id}      → Devuelve la información de un cliente específico.
- POST /api/customers          → Registra un nuevo cliente.
- PUT /api/customers/{id}      → Actualiza un cliente existente.
- DELETE /api/customers/{id}   → Elimina un cliente.

GESTIÓN DE PRODUCTOS
--------------------
Controlada por ProductController.cs
- GET /api/products            → Devuelve el listado de productos.
- GET /api/products/{id}       → Obtiene los detalles de un producto.
- POST /api/products           → Registra un nuevo producto.
- PUT /api/products/{id}       → Actualiza un producto.
- DELETE /api/products/{id}    → Elimina un producto.

GESTIÓN DE ÓRDENES
------------------
Controlada por OrderController.cs
- GET /api/orders              → Lista todas las órdenes.
- GET /api/orders/{id}         → Devuelve la información de una orden.
- POST /api/orders             → Crea una nueva orden.
- PUT /api/orders/{id}         → Actualiza una orden existente.
- DELETE /api/orders/{id}      → Elimina una orden.

---------------------------------------------
ARQUITECTURA DEL SISTEMA
---------------------------------------------
Controllers  → Gestionan las peticiones HTTP y las rutas.
Models       → Definen las clases de datos (Cliente, Producto, Orden).
Services     → Contienen la lógica de negocio.
Program.cs   → Configura la aplicación, servicios y middleware.

---------------------------------------------
CONFIGURACIÓN Y ENTORNO
---------------------------------------------
- appsettings.json: configuración base del entorno.
- appsettings.Development.json: configuración local.
- launchSettings.json: perfiles de ejecución.

La aplicación se ejecuta en:
HTTP:  http://localhost:5000
HTTPS: https://localhost:5001

---------------------------------------------
EJECUCIÓN DEL PROYECTO
---------------------------------------------
Requisitos:
- .NET SDK 8.0
- Visual Studio 2022 o Visual Studio Code
- Base de datos SQL Server configurada

Pasos:
1. Clonar el repositorio
   git clone https://github.com/tuusuario/Sistema-de-gestion-de-clientes-HU1Asp.Net.git
   cd Sistema-de-gestion-de-clientes-HU1Asp.Net/management.Api

2. Restaurar dependencias
   dotnet restore

3. Compilar el proyecto
   dotnet build

4. Ejecutar la API
   dotnet run

5. Probar en navegador o Postman:
   https://localhost:5001/api/customers
   https://localhost:5001/api/products
   https://localhost:5001/api/orders

---------------------------------------------
FLUJO DE USO
---------------------------------------------
1. El administrador registra un nuevo cliente.
2. Luego crea productos disponibles.
3. Genera una orden asociando cliente y productos.
4. Puede consultar, actualizar o eliminar registros.

---------------------------------------------
TECNOLOGÍAS UTILIZADAS
---------------------------------------------
- ASP.NET Core 8.0
- C#
- SQL Server
- Entity Framework Core
- JSON (System.Text.Json)
- Swagger / OpenAPI

---------------------------------------------
AUTOR
---------------------------------------------
Proyecto académico: HU1 – Sistema de Gestión de Clientes
Desarrollado por: Alejandro Santos
Lenguaje: C#
Framework: ASP.NET Core 8.0
Año: 2025
