# Mavi_CRUD_Net
Examen Practico SQL Server Desarrollador JR
• Crear una base de datos en ProServer en SQL Server llamada Contactos.
• Usando la Base de datos anterior crear una tabla usuario con los siguientes datos:
◦ Llave primaria auto incrementable.
◦ Campo Nickname(Nombre de usuario).
◦ Fecha de Registro, esta debe asignarse de manera automática cuando se realice un
insert.
◦ Correo electrónico, no debe permitir duplicidad de correos.
◦ Contraseña, debe almacenarse forma segura (hash o AES 256).
◦ Estatus del Usuario, puede ser de tipo enum o verdadero o falso, por default debe estar en
verdadero.
• Usando la base de datos anterior crear una segunda tabla contacto con los siguientes datos:
◦ Llave primaria auto incrementable.
◦ Fecha de registro, que debe asignarse de manera automática cuando se realiza un insert.
◦ Numero Teléfono, a 10 dígitos.
◦ Llave foránea con la tabla usuario.
• Realizar query para Crear, Actualizar, Consultar, Eliminar información de las tablas anteriores
(Usuario y Contacto), se puede utilizar Store Procedure, funciones de tabla a consideración
del programador.
Nota: Guardar en una carpeta con el nombre SQL todo lo realizado anteriormente.
Examen Practico Windows Form
• Crear un Proyecto en Windows forms, el cual deberá utilizar MVC y POO para la manipulación
y abstracción de la información, linQ y conexión a base de datos.
• Crear un formulario para registrar usuarios, tomando en cuenta los datos solicitados en la
tabla usuario, la cual deberá validar los siguientes datos:
◦ Solo letras en nickname.
◦ Validar formato de correo electrónico.
◦ Validar números y letras en contraseña y cifrar en has o aes 256.
◦ Crear una clase que represente la tabla
◦ Crear un controlador que realice las operaciones de CRUD.
• Crear un formulario para logear con la información anterior, el cual debe solicitar correo y
password, el formulario debe validar los siguientes datos:
◦ Formato correo electrónico.
◦ No caracteres especiales en password y cifrar en hash o aes 256.
◦ Crear una clase o usar un modelo.
◦ Crear o usar un controlador que permita realizar operaciones CRUD.
• Crear un formulario que permita mostrar en una GriedView los contactos almacenados del
usuario logeado, el formulario debe tener un buscador para realizar filtros a través del nombre
o número telefónico y actualizar la GridView con la información filtrada, dicho filtro se realizará
por linq, también deberá contar con un botón para eliminar contacto seleccionado, y agregar
otro botón para agregar o actualizar el registro seleccionado; a dicho botón al dar click deberá
mostrar un formulario con los campos de la tabla contactos y de ser necesario cargar la
información. Validación a considerar:
◦ Validación de solo letras a Nickname
◦ Validación de solo número con longitud de 10 posiciones como máximo.
◦ Crear o usar modelo para representación de tabla contacto.
◦ Crear o utilizar controlador para realizar operaciones CRUD. 
