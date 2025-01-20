using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Engage360plus.Models.DTO
{
    public class CustomerDetailsDto
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public AddressesDto Address { get; set; }
        public ProductStatusDto ProductStatus { get; set; }
        
    }
}
