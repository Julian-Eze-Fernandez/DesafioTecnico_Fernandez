# Prueba Tecnica "API de Productos"
Desarrollador: Julian Fernandez
Tecnologías utilizadas: .NET 8.0, Entity Framework Core, SQLite, AutoMapper, Swagger, Postman.
Descripción: API RESTful para la gestión de productos con operaciones CRUD y validaciones. 

Para este proyecto se utilizo arquitectura en capas y los siguientes paquetes Nuget:
- AutoMapper
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrrameworkCore.Tools
- Swasbuckle.AspNetCore

Ejecute el siguiente comando en la terminal para instalar automaticamente las dependencias.
```html
dotnet restore
```

###Intrucciones de Instalación
Antes de ejecutar el proyecto, verifica tener instalado en tu maquina:
- .NET SDK 8.0
- Postman

Como este proyecto utiliza SQLite, escribe este comando en la consola para ejecutar las migraciones y poder generar la base de datos. Ten en cuenta que se debe ejecutar en el proyecto "DataAccess".
```html
update-migration
```

## Como Ejecutar la API

Una vez tengas hayas completado los pasos anteriores, debes compilar y ejecutar el proyecto.
Hecho esto se abrira una ventana en el navegador web con "Swagger" donde apareceran los distintos metodos para poder interactuar con la API como GET, POST, PUT y DELETE. A continuacion se explicara el funcionamiento de cada uno de estos metodos:

### GET /api/products
Este metodo obtiene una lista con todos los productos cargados en formato JSON, por ejemplo:
```json
[
  {
    "id": 12,
    "name": "Pcsc",
    "description": "Computadora de escritorio",
    "price": 65.4,
    "quantity": 1
  },
  {
    "id": 22,
    "name": "Auricular Redragon H212 Cronus White RGB",
    "description": "Set de audífonos multiplataforma súper cómodos y livianos, con una calidad de sonido capaz de crear una atmósfera plenamente inmersiva.",
    "price": 25.1,
    "quantity": 8
  }
]
```
En caso de que no existieran productos cargados en el sistema, se devolvera una respuesta BadRequest `"No hay productos cargados en el sistema."`

### GET /api/products/{id}
Este metodo busca un producto en particular el cual se obtiene a traves de su identificador, solo se debe ingresar el **identificador** del producto que se quiere obtener y el sistema lo buscara. En caso de no existir dicho producto se le devolvera el mensaje al usuario `"No se encontro el producto con el identificador (id)"`.

###POST /api/products
Este endpoint le permite al usuario ingresar los datos del producto a crear y posteriormente agregarlo a la base de datos. Aqui se realizaron varias validaciones, como por ejemplo:
- El nombre del producto tiene una longitud minima de 3 caracteres.
- El nombre del producto es obligatorio.
- El nombre del producto no puede ser igual a otro.
- El precio debe ser un valor positivo.
- La cantidad al igual que el precio debe ser positiva.

Asi se le presentara al usuario el JSON a llnear con la informacion:
```json
{
  "id": 0,
  "name": "string",
  "description": "string",
  "price": 0,
  "quantity": 0
}
```
y asi seria un ejemplode como debe quedar al completarse:

```json
{
  "id": 4,
  "name": "Teclado Mecanico",
  "description": "Teclado mecanico 75% con switches blue",
  "price": 59.450,
  "quantity": 4
}
```

### PUT /api/products/{id}
En este metodo el usuario debe indicar el numero de identificador del producto a modificar y luego escribir los datos actualizados que se quieran cambiar.
La estructura del JSON que se presenta es identica al del metodo POST pero modificamos la descripcion de "switches blue" a "switches red":

```json
{
  "id": 4,
  "name": "Teclado Mecanico",
  "description": "Teclado mecanico 75% con switches red",
  "price": 59.450,
  "quantity": 4
}
```
En caso que se quieran ingresar valores no permitidos como el nombre de otro producto, valores negativos en la cantidad o en el precio, la respuesta a la solicitud sera un BadRequest con un mensaje personalizado en cada caso.

###DELETE /api/products
Este endpoint permite eliminar un producto de la base de datos según su ID. Aqui el usuario ingresa el identiicador del producto a eliminar y si este mismo existe se borrara de la base de datos al ejecutar el metodo, en caso contrario se le devolvera un mensaje "No existe el producto con id (numero de id)".

## Pruebas con Postman
Este proyecto cuenta con una coleccion de Postman con pruebas automatizadas. Para eso debe:
- Dirigirse a Postman.
- Importar el archivo postman_collection.json incluido en el repositorio.
- Ejecutar las pruebas para verificar el funcionamiento de la API.
