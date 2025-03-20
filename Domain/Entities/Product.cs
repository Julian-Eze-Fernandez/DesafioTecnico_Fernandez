
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public string Description { get; set; }
		public required double Price { get; set; }
		public int Quantity { get; set; }
	}
}
