using Business;
using Business.DTOs.ProductsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico_Fernandez.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductController : ControllerBase
	{
		private readonly ProductBusiness productBusiness;

		public ProductController(ProductBusiness productBusiness)
		{
			this.productBusiness = productBusiness;
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductDTO>>> GetProductAll()
		{
			try
			{
				var products = await productBusiness.ListProducts();

				return Ok(products);
			}
			catch (InvalidOperationException x)
			{
				return BadRequest(x.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDTO>> GetProductById(int id)
		{
			try
			{
				var product = await productBusiness.ProductById(id);

				return Ok(product);
			}
			catch (InvalidOperationException x)
			{
				return BadRequest(x.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO productCreationDTO)
		{
			try
			{
				var product = await productBusiness.CreateProduct(productCreationDTO);

				return Ok(product);
			}
			catch (InvalidOperationException x)
			{
				return BadRequest(x.Message);
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<ProductDTO>> PutProduct(ProductDTO productDTO)
		{
			try
			{
				var product = await productBusiness.UpdateProduct(productDTO);

				return Ok(product);
			}
			catch (InvalidOperationException x)
			{
				return BadRequest(x.Message);
			}

		}

		[HttpDelete]
		public async Task<ActionResult> DeleteProductById(int id)
		{
			try
			{
				var product = await productBusiness.DeleteProduct(id);
				return Ok($"El producto de id {id} fue eliminado exitosamente");
			}
			catch (InvalidOperationException x)
			{
				return BadRequest(x.Message);
			}

		}
	}
}
