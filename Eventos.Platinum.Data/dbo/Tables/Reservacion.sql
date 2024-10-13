CREATE TABLE [dbo].[Reservacion]
(
	[ReservacionId] INT NOT NULL PRIMARY KEY, 
    [SalaId] INT NOT NULL, 
    [NombreCliente] VARCHAR(100) NOT NULL, 
    [CorreoCliente] VARCHAR(100) NOT NULL, 
    [TelefonoCliente] VARCHAR(50) NOT NULL, 
    [Fecha] DATETIME NOT NULL
)
