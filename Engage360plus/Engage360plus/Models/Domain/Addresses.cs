using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Engage360plus.Models.Domain
{
    public class Addresses
    {
        
        public Guid Id {  get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
