using System.ComponentModel.DataAnnotations;

namespace Engage360plus.Models.DTO
{
    public class AddCustomerRequestDto
    {
        public Guid CustomerID { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerEmail { get; set; }
        [MaxLength(1000)]
        public Guid AddressId { get; set; }
        //public int Id { get; set; }
        public Guid ProductStatusId { get; set; }

        /*public AddressesDto Addresses { get; set; }
        public ProductStatusDto ProductStatus { get; set; }*/
    }
}
