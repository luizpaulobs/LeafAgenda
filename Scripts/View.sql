
CREATE VIEW vw_evento as
SELECT Usuarios.Nome AS NomeUsuario, 
Eventos.Nome as NomeEvento,
Eventos.Data as DataEvento,
Eventos.Compartilhado as TipoEvento
from Eventos
INNER JOIN Usuarios ON Eventos.UsuarioId = Usuarios.Id

