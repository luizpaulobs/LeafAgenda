CREATE PROCEDURE sp_evento
(
	@NomeUsuario as NVARCHAR(MAX),
	@Data as NVARCHAR(MAX)
)
as
SELECT Usuarios.Nome AS NomeUsuario, 
Eventos.Nome as NomeEvento,
Eventos.Data as DataEvento,
Eventos.Compartilhado as TipoEvento
from Eventos
INNER JOIN Usuarios ON Eventos.UsuarioId = Usuarios.Id
WHERE (@NomeUsuario IS NULL OR Usuarios.Nome = @NomeUsuario)
AND (@Data IS NULL OR Eventos.Data = @Data)