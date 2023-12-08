---------------------------------------------------------------------------
---------------------------------------------------------------------------
----------------Examen Practico SQL Server Desarrollador JR----------------
---------------------------------------------------------------------------
---------------------------------------------------------------------------
--CREAR BASE DE DATOS CONTACTOS
CREATE DATABASE Contactos;

--Tabla usuario
CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nickname VARCHAR(50) NOT NULL,
	FechaRegistro DATETIME DEFAULT GETDATE(),
	CorreoElectronico VARCHAR(100) UNIQUE,
	ClaveUsuario VARCHAR(400) NOT NULL,
	EstadoUsuario VARCHAR(10) DEFAULT 'VERDADERO'
);

--Tabla contacto
CREATE TABLE Contacto (
	IdContacto INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	FechaRegistro DATETIME DEFAULT GETDATE(),
	NumeroTelefono VARCHAR(50) NOT NULL,
	IdUsuario INT,
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

--SP Inserta Usuario 
	CREATE PROCEDURE InsertarUsuario
		@Nickname VARCHAR(50),
		@CorreoElectronico VARCHAR(100),
		@ClaveUsuario VARCHAR(100)
	AS
	BEGIN
		DECLARE @hash_ClaveUsuario VARBINARY(256);
		SET @hash_ClaveUsuario = HASHBYTES('SHA2_256', @ClaveUsuario);

		INSERT INTO Usuario (Nickname, CorreoElectronico, ClaveUsuario) 
		VALUES (@Nickname, @CorreoElectronico, @hash_ClaveUsuario);
	END;
EXEC InsertarUsuario 'Austin', 'austintv52@gmail.com', 'mavi';
--SP Verifica Usuario
	CREATE PROCEDURE VerificarUsuario
		@Nickname VARCHAR(50),
		@CorreoElectronico VARCHAR(100),
		@ClaveUsuario VARCHAR(100)
	AS
	BEGIN
		DECLARE @hash_clave_ingresada VARBINARY(256);
		SET @hash_clave_ingresada = HASHBYTES('SHA2_256', @ClaveUsuario);

		SELECT * FROM Usuario 
		WHERE Nickname = @Nickname 
		AND CorreoElectronico = @CorreoElectronico 
		AND ClaveUsuario = @hash_clave_ingresada;
	END;
EXEC VerificarUsuario 'Austin', 'austintv52@gmail.com', 'mavi';
--SP Actualizar Usuario
	CREATE PROCEDURE ActualizarUsuario
		@IdUsuario INT,
		@n_Nickname VARCHAR(50),
		@n_CorreoElectronico VARCHAR(100),
		@n_ClaveUsuario VARCHAR(100),
		@n_EstadoUsuario VARCHAR(10)
	AS
	BEGIN
		DECLARE @hash_ClaveUsuario VARBINARY(256);
		SET @hash_ClaveUsuario = HASHBYTES('SHA2_256', @n_ClaveUsuario);

		UPDATE Usuario
		SET Nickname = @n_Nickname,
			CorreoElectronico = @n_CorreoElectronico,
			ClaveUsuario = @hash_ClaveUsuario,
			EstadoUsuario = @n_EstadoUsuario
		WHERE IdUsuario = @IdUsuario
	END;
EXEC ActualizarUsuario 1, 'Agus', 'au.arenasm@mavi.mx', 'Mavi2023', 'Falso';
--SP Eliminar Usuario 
	CREATE PROCEDURE EliminarUsuario
		@IdUsuario INT
	AS
	BEGIN
		DELETE FROM Usuario
		WHERE IdUsuario = @IdUsuario;
	END;
EXEC EliminarUsuario 2; 