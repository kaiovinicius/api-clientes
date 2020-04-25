using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace api_clientes.Entities
{
    public partial class Contato
    {
        [Key]
        public int? Id { get; set; }
        public int IdCliente { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}