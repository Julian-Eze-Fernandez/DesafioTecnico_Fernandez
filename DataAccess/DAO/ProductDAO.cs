using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
			var products = await context.Products.ToListAsync();

			if (products == null || products.Count == 0)
			{
				throw new InvalidOperationException("No hay productos cargados en el sistema.");
			}

			return products ;
		}
		public async Task<Product> GetById(int id) {
			var product = await context.Products.FindAsync(id);

			if (product != null)
				return product;

			if (product == null)
			{
				throw new InvalidOperationException($"No se encontro el producto con el identificador {id}");
			}

			return null;
		}
		public async Task<Product> Create(Product product)
		{
			await ValidationProduct(product);

			context.Add(product);
			await context.SaveChangesAsync();
			return product;
		}
		public async Task<Product> Update(Product newProduct)
		{
			var product = await context.Products.FindAsync(newProduct.Id);
			product.Name = newProduct.Name;
			product.Description = newProduct.Description;
			product.Price = newProduct.Price;
			product.Quantity = newProduct.Quantity;

			await ValidationProduct(newProduct);

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

			throw new InvalidOperationException($"No existe el producto con id {id}.");

			//return false;
		}

		public async Task ValidationProduct(Product product)
		{
			if (product == null)
			{
				throw new InvalidOperationException($"El nombre del producto es obligatorio");
			}

			if (product.Name.Length < 3)
			{
				throw new InvalidOperationException($"El nombre del producto debe tener como minimo 3 caracteres");

			}

			var producExists = await context.Products.AnyAsync(x => x.Name == product.Name && x.Id	!= product.Id);

			if (producExists)
			{
				throw new InvalidOperationException($"El producto {product.Name} ya existe");
			}


			if (product.Price < 0)
			{
				throw new InvalidOperationException($"El precio {product.Price} no es valido");
			}

			if (product.Quantity < 0)
			{
				throw new InvalidOperationException($"La cantidad ingresada no es valida");
			}
		}

	}
}
