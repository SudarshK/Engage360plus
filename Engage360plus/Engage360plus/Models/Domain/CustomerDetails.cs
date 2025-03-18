using Engage360plus.Models.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace Engage360plus.Models.Domain
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public Guid AddressId {  get; set; }
        //public int Id {  get; set; }
        public Guid ProductStatusId {  get; set; }
        //Navigation Properties
        public Addresses Address { get; set; }
        //public CustomerProduct? Product { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }

}
