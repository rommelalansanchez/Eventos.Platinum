CREATE PROCEDURE [dbo].[spSalaGet]
AS
	 SELECT [SalaId]
      ,[Nombre]
      ,[Capacidad]
     FROM [dbo].[Sala]
