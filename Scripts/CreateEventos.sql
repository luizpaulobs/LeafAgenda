USE [agendadb]
GO


CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Participantes] [int] NOT NULL,
	[Compartilhado] [bit] NOT NULL,
	[Hora] [nvarchar](max) NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Eventos] ADD  DEFAULT (N'') FOR [Hora]
GO

ALTER TABLE [dbo].[Eventos] ADD  DEFAULT ((0)) FOR [UsuarioId]
GO


