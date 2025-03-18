namespace Engage360plus.Models.DTO
{
    public class UpdateCustomerRequestDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public Guid AddressId { get; set; }
        //public int Id {  get; set; }
        public Guid ProductStatusId { get; set; }
    }
}
