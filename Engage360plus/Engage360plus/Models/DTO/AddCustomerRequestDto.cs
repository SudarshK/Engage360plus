namespace Engage360plus.Models.DTO
{
    public class AddCustomerRequestDto
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public Guid AddressId { get; set; }
        //public int Id { get; set; }
        public Guid ProductStatusId { get; set; }

        /*public AddressesDto Addresses { get; set; }
        public ProductStatusDto ProductStatus { get; set; }*/
    }
}
