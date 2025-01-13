namespace Engage360plus.Models.DTO
{
    public class CustomerDetailsDto
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public AddressesDto Addresses { get; set; }
        public ProductStatusDto ProductStatus { get; set; }
        
    }
}
