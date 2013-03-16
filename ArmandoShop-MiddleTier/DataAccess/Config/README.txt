************************* Armando Shop Data Acces details *******************************

Los ficheros en Config contienen la configuración de acceso a datos, proveedor de datos de 
ADO.NET , SQL para todas las consultas por clave, y los beans de spring de todos los 
DAO injectados desde nuestra factoria.

*****************************************************************************************

El fichero de spring es opcional si se va usar esta ddl desde otra que use spring, 
entonces bastará con incluir este fichero para tener todos los daos en el 
contexto de Spring.

******************************************************************************************

El fichero DataAcces.config es VITALL, desde la ddl que use esta se debe importar 
este fichero, esto es o bien copiando su contenido al fichero de configuración de la aplicación 
en cuestión, o con una linea asi : <appSettings file="DataAccess.config"/> en dicho fichero.
En este ultimo caso el fichero importado se debe colocar a la altura de la ddl, en bin,
no en las carpetas de desarrollo.

******************************************************************************************