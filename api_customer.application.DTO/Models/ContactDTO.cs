using System.ComponentModel.DataAnnotations;

namespace api_customer.application.DTO.Models
{
    public partial class ContactDTO
    {
        public int? Id { get; set; }
        public int IdCustomer { get; set; }
        [Required]
        public string Ddd { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual CustomerDTO Customer { get; set; }
    }
}
