CREATE DATABASE ExamenAtilano
USE ExamenAtilano
CREATE TABLE [User](
	  [Id_User] INT PRIMARY KEY IDENTITY (1,1),
      [Name] NVARCHAR(60),
      [LastName] NVARCHAR(60),
      [Password] NVARCHAR(60),
      [Nick] NVARCHAR(60),
      [Estatus] BIT DEFAULT 1,
      [Imagen] NVARCHAR(60)
)
CREATE TABLE Alumno(
	  [Id_Alumno] INT PRIMARY KEY IDENTITY (1,1),
      [Materia] NVARCHAR(60),
      [Grupo] NVARCHAR(60),
      [Semestre] NVARCHAR(60),
      [Computadora] NVARCHAR(60),
      [Estatus] BIT DEFAULT 1,
)
CREATE PROCEDURE sp_InAlumno
@_Materia NVARCHAR(60),
@_Grupo NVARCHAR(60),
@_Semestre NVARCHAR(60),
@_Computadora NVARCHAR(60)

AS
	 INSERT INTO Alumno (Materia,Grupo,Semestre,Computadora) VALUES (@_Materia,@_Grupo,@_Semestre,@_Computadora)
		DECLARE @lastId INT
	SET @lastId = (SELECT MAX(Id_Alumno) FROM Alumno)
	SELECT * FROM Alumno WHERE Id_Alumno = @lastId;
	EXEC sp_AddUsuario 'l','l','123';

ALTER PROCEDURE sp_AddUsuario
@_Name NVARCHAR(60),
@_Nick NVARCHAR(60),
@_Password NVARCHAR(60)
AS
	INSERT INTO [User] ([Name],Nick,[Password]) VALUES (@_Name,@_Nick,@_Password)
		DECLARE @lastId INT
	SET @lastId = (SELECT MAX(Id_User) FROM [User])
	SELECT * FROM [User] WHERE Id_User = @lastId;
	EXEC sp_AddUsuario 'l','l','123';