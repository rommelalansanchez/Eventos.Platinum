CREATE PROCEDURE [dbo].[spUsuarioGet]
	@UsuarioId int = NULL
AS
BEGIN
    SELECT 
        [UsuarioId], 
        [NombreUsuario], 
        [Activo] , 
        [FechaUltimoIngreso],
        [UsuarioTipoId],
        [Password] AS [PasswordHash],
        [Salt]
    FROM [dbo].[Usuario]
    WHERE @UsuarioId IS NULL OR [UsuarioId]=@UsuarioId
END