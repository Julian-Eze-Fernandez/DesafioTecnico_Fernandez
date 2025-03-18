﻿
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public required string Name { get; set; }
		public string Description { get; set; }
		[Required]
		public required double Price { get; set; }
		public int Quantity { get; set; }
	}
}
