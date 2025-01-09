using System;
using System.ComponentModel.DataAnnotations;
namespace Engage360plus.Models.Domain
{
	public class CustomerProduct
	{
		[Key]
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
	}
}
