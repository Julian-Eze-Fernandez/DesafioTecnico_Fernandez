using AutoMapper;
using Business.DTOs.ProductsDTOs;
using DataAccess;
using DataAccess.DAO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Business
{
	public class ProductBusiness
	{
		private readonly IMapper mapper;
		private readonly ProductDAO productDao;

		public ProductBusiness(ProductDAO productDao, IMapper mapper)
		{			
			this.mapper = mapper;
			this.productDao = productDao;
		}


		public async Task<List<ProductDTO>> ListProducts()
		{
			var products = await productDao.GetAll();
			return mapper.Map<List<ProductDTO>>(products);
		}

		public async Task<ProductDTO> ProductById(int id)
		{
			var product = await productDao.GetById(id);
			return mapper.Map<ProductDTO>(product);
		}

		public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
		{

			var newProduct = mapper.Map<Product>(productDTO);

			newProduct = await productDao.Create(newProduct);

			productDTO.Id = newProduct.Id;
			
			return (productDTO);
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var product = await productDao.Delete(id);

			return true;
		}

		public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
		{

			var newProduct = mapper.Map<Product>(productDTO);

			newProduct = await productDao.Update(newProduct);

			return (productDTO);
		}
	}
}
