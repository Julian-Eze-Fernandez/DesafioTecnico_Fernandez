using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	internal class Product
	{
		public int idProduct { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public double price { get; set; }
		public int quantity { get; set; }
	}
}
