using System.ComponentModel.DataAnnotations;

namespace api_clientes.Entities
{
    public partial class Cliente
    {
        [Key]
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }

        public virtual Contato Contato { get; set; }
    }
}
