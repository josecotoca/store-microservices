# _store-microservices_

## _Microservices for store_

El presente repositorio es un ejemplo práctico de microservicios aplicando el patron CQRS en Dotnet Core 6.
Los end points habilitados son los siguientes:

# _Product_ #

|Ruta||Función|
|----------|----------|----------|
|/api/products|GET| Listado de productos|
|/api/products|POST| Registra nuevo producto o servicio|
|/api/products/{id}|PUT|Actualiza producto existente|
|/api/products/{id}|GET|Recupera un producto seleccionado por Id|
|/api/products/{id}|DELETE|Elimina un producto de la lista de productos|

# _Transaction_ #

|Ruta||Función|
|----------|----------|----------|
|/api/transactions|POST| Registra una ingreso o egreso de inventario|
|/api/transactions/deliver|POST|Realiza la entrega de productos pendientes de entrega, solo las salidas de inventario cumplen esta funcion en 2 pasos|

# _ShopinCart_ #
|Ruta||Función|
|----------|----------|----------|
|/api/sales/{id}|GET| Seleccionar una venta y detalle de productos|
|/api/sales|POST| Registra nueva venta aplicando por configuracion un recargo por 13% sobre el total de la venta y mueve inventario a pendiente de entrega|
|/api/sales/deliver/{id}|POST|Realiza la entrega de productos pendientes de entre por una venta|


El MicroServicio de productos se encuentra disponible en el api:
```sh
http://localhost:5243
```
El Microservicio de ventas se encuentra en la api: 
```sh
http://localhost:5131
```

La migración de base de datos en el presente ejemplo la puede realizar en PostgreSQL :
```sh
CREATE DATABASE store_db;
```


Importar desde archivo store_db.sql o correr en ambos proyectos : 
```sh
dotnet ef database update
```
Cadena de conexion es posible cambiar en ambos microservicios en appsettins.json "ConnectionStrings".