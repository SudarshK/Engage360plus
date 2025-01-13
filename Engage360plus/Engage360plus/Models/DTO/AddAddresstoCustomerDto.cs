using System.Text.Json.Serialization;

namespace Engage360plus.Models.DTO
{
    public class AddAddresstoCustomerDto
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
