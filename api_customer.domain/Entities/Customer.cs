using System.ComponentModel.DataAnnotations;

namespace api_customer.domain.Entities
{
    public partial class Customer
    {
        [Key]
        public int? Id { get; set; }
        public int? IdAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cpf { get; set; }
        public char Genre { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
