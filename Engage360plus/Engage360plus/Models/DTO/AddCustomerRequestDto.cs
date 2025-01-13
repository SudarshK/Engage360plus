namespace Engage360plus.Models.DTO
{
    public class AddCustomerRequestDto
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public int AddressId { get; set; }
        //public int ProductID { get; set; }
        public int StatusId { get; set; }

        public AddressesDto Addresses { get; set; }
        public ProductStatusDto ProductStatus { get; set; }
    }
}
