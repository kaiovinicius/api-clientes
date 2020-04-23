using System.ComponentModel.DataAnnotations;

namespace api_clientes_ma9.application.Models
{
    public partial class ClienteDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public char Sexo { get; set; }

        public virtual ContatoDTO Contato { get; set; }
    }
}
