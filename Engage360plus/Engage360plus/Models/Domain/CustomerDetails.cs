using Engage360plus.Models.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace Engage360plus.Models.Domain
{
    public class CustomerDetails
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public int AddressId {  get; set; }
        //public int ProductID {  get; set; }
        public int StatusId {  get; set; }
        //Navigation Properties
        public Addresses Addresses { get; set; }
        //public CustomerProduct? Product { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }

}
