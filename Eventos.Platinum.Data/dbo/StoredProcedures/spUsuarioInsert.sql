CREATE PROCEDURE [dbo].[spUsuarioInsert]
	@UsuarioId	int,
	@NombreUsuario	nvarchar(100),
	@Password	varbinary(MAX),
	@Salt	varbinary(MAX),
	@Activo	nchar(10),
	@FechaUltimoIngreso	datetime2(7),
	@UsuarioTipoId int
AS
BEGIN
	IF(@UsuarioId IS NULL)
		SET @UsuarioId=(SELECT ISNULL(MAX(UsuarioId)+1,1) FROM Usuario)

	INSERT INTO Usuario(UsuarioId, NombreUsuario, Password, Salt, Activo, FechaUltimoIngreso, UsuarioTipoId)
	VALUES (@UsuarioId, @NombreUsuario, @Password, @Salt, @Activo, @FechaUltimoIngreso, @UsuarioTipoId)

	SELECT @UsuarioId
END