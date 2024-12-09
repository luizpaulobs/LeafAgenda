using System.ComponentModel.DataAnnotations;

namespace AgendaLeaf.Models
{
    public class Eventos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Data { get; set; }

        public string Hora { get; set; }

        public int Participantes { get; set; }

        public bool Compartilhado { get; set; }
        public int UsuarioId { get; set; }
    }
}
