using AutoMapper;
using Business.DTOs.ProductsDTOs;
using DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
	public class ProductBusiness
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public ProductBusiness(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}


		public async Task<List<ProductDTO>> ListProducts()
		{
			var products = await context.Products.ToListAsync();

			return mapper.Map<List<ProductDTO>>(products);
		}

		public async Task<ProductDTO> ProductById(int id)
		{
			var product = await context.Products.FirstOrDefaultAsync(productBD => productBD.Id == id);
			return mapper.Map<ProductDTO>(product);
		}

		public async Task<bool> CreateProduct(ProductCreationDTO productCreationDTO)
		{
			var newProduct = mapper.Map<Product>(productCreationDTO);

			context.Add(newProduct);
			await context.SaveChangesAsync();
			return (true);
		}
	}
}
