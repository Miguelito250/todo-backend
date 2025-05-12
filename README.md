# 🧠 Task Manager API – Instalación y Configuración Local

Este proyecto es una API RESTful construida con **.NET 8** y utiliza **SQL Server 2019 Developer Edition** como base de datos. A continuación, los pasos necesarios para clonar, configurar y ejecutar el proyecto en el entorno local.

---

## To-do backend
### 🏗️ Arquitectura utilizada
El proyecto sigue una arquitectura en capas, también conocida como N-Tier Architecture, que se caracteriza por separar la aplicación en diferentes capas con responsabilidades bien definidas:

Capa de Presentación: Maneja la interacción con el usuario o cliente. En este caso, los controladores en la carpeta Controllers/ actúan como la capa de presentación, recibiendo las solicitudes HTTP y devolviendo las respuestas correspondientes.

Capa de Aplicación/Servicios: Contiene la lógica de negocio y coordina las operaciones entre la capa de presentación y la de datos. La carpeta Services/ implementa esta capa, proporcionando métodos que los controladores pueden invocar para realizar acciones específicas.

Capa de Dominio/Modelos: Representa las entidades y reglas de negocio fundamentales. La carpeta Models/ define las clases que representan las entidades del dominio.

Capa de Acceso a Datos: Se encarga de la interacción con la base de datos. La carpeta Data/ contiene el contexto de la base de datos y las interfaces de los repositorios que abstraen el acceso a los datos.

---

### Principios SOLID y patrón Repository
El diseño del proyecto refleja la aplicación de los principios SOLID:

S (Single Responsibility Principle): Cada clase tiene una única responsabilidad. Por ejemplo, los controladores manejan las solicitudes HTTP, los servicios contienen la lógica de negocio y los repositorios gestionan el acceso a los datos.

O (Open/Closed Principle): El sistema está abierto para la extensión pero cerrado para la modificación. Se pueden agregar nuevas funcionalidades sin alterar el código existente, gracias al uso de interfaces y clases abstractas.

L (Liskov Substitution Principle): Las clases derivadas pueden sustituir a sus clases base sin alterar el comportamiento del programa. Esto se logra mediante la implementación coherente de interfaces.

I (Interface Segregation Principle): Se prefieren interfaces específicas y pequeñas en lugar de interfaces generales y grandes, lo que facilita la implementación y el mantenimiento.

D (Dependency Inversion Principle): Las dependencias se inyectan a través de interfaces, lo que permite una mayor flexibilidad y facilidad para realizar pruebas.

El uso del patrón Repository en la carpeta Data/ permite abstraer el acceso a los datos, proporcionando una interfaz común para interactuar con la base de datos. Esto facilita el mantenimiento y la escalabilidad del código, ya que los detalles de implementación del acceso a los datos están encapsulados y separados de la lógica de negocio.

---
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
