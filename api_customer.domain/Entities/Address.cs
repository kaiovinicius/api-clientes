using System.ComponentModel.DataAnnotations;

namespace api_customer.domain.Entities
{
    public class Address
    {
        [Key]
        public int? Id { get; set; }
        public string ZipCode { get; set; }
        public string PublicArea { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
