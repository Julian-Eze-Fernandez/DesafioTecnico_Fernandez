﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.ProductsDTOs
{
	public class ProductCreationDTO
	{
		[Required]
		public required string Name { get; set; }
		public string Description { get; set; }
		[Required]
		public required double Price { get; set; }
		public int Quantity { get; set; }
	}
}
