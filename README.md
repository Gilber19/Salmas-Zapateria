# Salmas-Zapatería

**Descripción:**  
Este es un proyecto de aplicación web para Salmas-Zapatería, una plataforma de comercio electrónico diseñada para la venta de zapatos. La aplicación permite a los usuarios ver el catálogo, gestionar el carrito de compras, y realizar pedidos, todo en una interfaz fácil de usar y adaptada a dispositivos móviles gracias a Bootstrap.

## Tecnologías Utilizadas

- **C#** - Lenguaje de programación principal.
- **ASP.NET Core** - Framework para desarrollo web.
- **Entity Framework Core** - ORM para la interacción con la base de datos.
- **Bootstrap** - Framework CSS para diseño responsivo.
- **SQL Server** - Base de datos relacional.

## Características

- **Catálogo de productos**: Visualización de los zapatos disponibles, con detalles como precio, tallas y descripciones.
- **Carrito de compras**: Los usuarios pueden agregar productos y revisar su carrito antes de realizar una compra.
- **Gestión de usuarios**: Registro e inicio de sesión para gestionar pedidos e historial de compras.
- **Sistema de pagos**: Integración con una pasarela de pago para facilitar las transacciones.

## Requisitos Previos

- **.NET SDK 8.0**

    Para instalar SDK, ingresar al siguiente enlace
    >https://download.visualstudio.microsoft.com/download/pr/acd3875c-e28a-46a1-85fd-e99948175d90/a98148f58ddb7cc1d31305e1e5244518/dotnet-sdk-8.0.404-win-x86.exe

- **SQL Server**  
- **Node.js y NPM** - (opcional, si se necesita para la compilación de scripts o paquetes adicionales de JavaScript)

## Para compilar

- **Para compilar el proyecto completo, utiliza el siguiente comando en la terminal:**
    ```bash
    dotnet build
- **Para ejecutar el programa desde la consola:**
    ```bash
    dotnet run
- **Si se quiere agregar una nueva clase, en la terminal se coloca lo siguiente**
    ```bash
    dotnet new classlib -o NombreDeLaClase
    ```

    >Si necesitas crear otro tipo de proyecto, como una Web API o MVC, puedes reemplazar classlib por el tipo de proyecto correspondiente. Asegúrate de estar en la ruta adecuada antes de ejecutar el comando.
    