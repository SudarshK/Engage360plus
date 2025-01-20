using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Engage360plus.Models.DTO
{
    public class AddAddresstoCustomerDto
    {
        public Guid Id { get; set; }
        [Required]
        public string City { get; set; }
        [MaxLength(10)]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        
    }
}
