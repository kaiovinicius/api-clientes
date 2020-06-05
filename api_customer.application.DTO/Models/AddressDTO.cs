namespace api_customer.application.DTO.Models
{
    public class AddressDTO
    {
        public int? Id { get; set; }
        public string ZipCode { get; set; }
        public string PublicArea { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
