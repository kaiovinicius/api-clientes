using System.ComponentModel.DataAnnotations;

namespace api_customer.domain.Entities
{
    public partial class Contact
    {
        [Key]
        public int? Id { get; set; }
        public int IdCustomer { get; set; }
        public string Ddd { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public virtual Customer Customer { get; set; }
    }
}