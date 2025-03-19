using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

	public class ProductDAO
	{
		private readonly ApplicationDbContext context;

		public ProductDAO(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<List<Product>> GetAll()
		{
			return await context.Products.ToListAsync();
		}
		public async Task<Product> GetById(int id) {
			var product = await context.Products.FindAsync(id);
			if (product != null)
				return product;

			return null;
		}
		public async Task<Product> Create(Product product)
		{
			context.Add(product);
			await context.SaveChangesAsync();
			return product;
		}
		public async Task<Product> Update(Product newProduct, int id)
		{
			var product = await context.Products.FindAsync(id);
			product = newProduct;
			context.Update(product);
			await context.SaveChangesAsync();
			return product;
		}
		public async Task<bool> Delete(int id)
		{
			var product = await context.Products.FindAsync(id);
			if (product != null)
			{
				context.Products.Remove(product);
				await context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
