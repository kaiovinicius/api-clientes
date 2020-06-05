using System.ComponentModel.DataAnnotations;

namespace api_customer.application.DTO.Models
{
    public partial class CustomerDTO
    {
        public int? Id { get; set; }
        public int? IdAddress { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public char Genre { get; set; }

        public virtual ContactDTO Contact { get; set; }
    }
}
