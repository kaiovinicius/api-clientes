using System.ComponentModel.DataAnnotations;

namespace api_clientes.domain.Entities
{
    public class Endereco
    {
        [Key]
        public int? Id { get; set; }
        public int? IdCliente { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
