using System.ComponentModel.DataAnnotations;

namespace Engage360plusUI.Models
{
    public class AddAddressViewModel
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
