Se le solicita desarrollar un WebService para registrar contacto con sus respectivos teléfonos,
deberá contar con sistema de login, (usuario y password), para poder acceder a los contactos y
sus teléfonos.

Consideraciones:
 Para el acceso de datos usar Entity Framework con el motor de SQL,
 Puede usar Code First o DataBase First, de usar DataBase Firts por favor enviar el
script para la creación de la base de datos.
 Usar JWT (Json Web Token) para autorización.
 Deberá tener como mínimo los siguientes EndPoint:
o GetAll: Trae todos los contactos con su lista de teléfonos.
o GetName: Trae el contacto que coincida con el nombre
o GetTelefono:
o Create: Crea un contacto con sus teléfonos.
 Deberá contar con EndPoint para el login
 Como desarrollador esta a su criterio el poder agregar más End Point, agregar más
entities o funcionalidad extra.

se agregan los siguientes EndPoints
[HttpGet("GetNombreApellido/{nombre}/{apellido}")]
[HttpPost("CreateTelefono{nombre}/{apellido}/telefonos")]
[HttpDelete("Delete/{nombre}/{apellido}")]
[HttpDelete("DeleteTelefono/{telefono}")]
