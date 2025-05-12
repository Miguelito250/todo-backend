# 🧠 Task Manager API – Instalación y Configuración Local

Este proyecto es una API RESTful construida con **.NET 8** y utiliza **SQL Server 2019 Developer Edition** como base de datos. El proyecto todo-backend implementa una arquitectura en capas que sigue los principios SOLID y utiliza el patrón Repository para estructurar el código de manera modular y mantenible. A continuación, los pasos necesarios para clonar, configurar y ejecutar el proyecto en el entorno local.

---

## ✅ Requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server 2019 Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- Git

---

## 🚀 Instalación del proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo/todo-backend
```
Asegúrate de entrar a la carpeta donde está el proyecto .csproj.

### 2. Restaurar paquetes NuGet
Ejecuta este comando para instalar todas las dependencias necesarias:

```bash
dotnet restore
```
### 3. Configurar la base de datos
Asegúrate de tener una instancia de SQL Server en funcionamiento. Si no la tienes, sigue los pasos abajo para instalar SQL Server 2019 Developer.

Edita el archivo appsettings.json para apuntar a tu instancia local:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Si usas autenticación por usuario y contraseña:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskManagerDb;User Id=tu_usuario;Password=tu_password;TrustServerCertificate=True;"
}
```

### 4. Aplicar migraciones 
ejecuta para aplicar las migraciones a la base de datos:

```bash
dotnet ef database update
```

### 5. Ejecutar el proyecto
Desde la carpeta del proyecto:

```bash
set ASPNETCORE_URLS=http://localhost:7287
dotnet run
```
Esto iniciará el backend en el puerto configurado, por ejemplo: https://localhost:5159 o http://localhost:7287. (7287 es el que esta configurado en el frontend) 


### 🛠️ Instalación de SQL Server 2019 Developer
#### 1. Descargar el instalador
Descargar SQL Server 2019 Developer Edition

#### 2. Instalación básica
Selecciona Developer Edition.

Usa la opción de instalación básica o personalizada.

Espera a que termine la instalación.

#### 3. Configurar instancia
Asigna un nombre de instancia (o usa default).

Asegúrate de habilitar Mixed Mode Authentication si deseas usar usuario/contraseña.

#### 4. Instalar SSMS (opcional, pero recomendado)
Instálalo para gestionar la base de datos fácilmente.
