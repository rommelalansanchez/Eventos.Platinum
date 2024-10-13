CREATE TABLE [dbo].[Usuario]
(
	[UsuarioId] INT NOT NULL PRIMARY KEY, 
    [NombreUsuario] NVARCHAR(100) NOT NULL, 
    [Password] VARBINARY(MAX) NOT NULL, 
    [Salt] VARBINARY(MAX) NOT NULL, 
    [Activo] BIT NOT NULL, 
    [FechaUltimoIngreso] DATETIME2 NULL, 
    [UsuarioTipoId] INT NOT NULL
)
