using System.ComponentModel.DataAnnotations;

namespace Engage360plus.Models.Domain
{
    public class ProductStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
