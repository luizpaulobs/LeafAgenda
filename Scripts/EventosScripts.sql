USE [agendadb]
GO

INSERT INTO [dbo].[Eventos]
           ([Nome]
           ,[Descricao]
           ,[Data]
           ,[Participantes]
           ,[Compartilhado]
           ,[Hora]
           ,[UsuarioId])
     VALUES
           ('Reunião','Reunião geral','2024-12-06',5,1,'17:40',1),
		   ('Reunião2','Reunião diretoria','2024-12-07',2,1,'13:30',1)


UPDATE [dbo].[Eventos] SET [Participantes] = 10,[Hora] = '16:30' WHERE Id = 14


DELETE FROM [dbo].[Eventos]  WHERE Id = 15


