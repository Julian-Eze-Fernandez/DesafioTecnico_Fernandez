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
			var products = await productBusiness.ListProducts();

			if (products == null || products.Count == 0) 
			{
				return BadRequest("No hay productos cargados en el sistema.");
			}

			return Ok(products);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductDTO>> GetProductById(int id)
		{
			var product = await productBusiness.ProductById(id);

			if (product == null) 
			{
				return BadRequest($"No existe el producto con el identificador {id}");
			}

			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> PostProduct(ProductCreationDTO productCreationDTO)
		{
			var resultado = await productBusiness.CreateProduct(productCreationDTO);

			if (!resultado)
			{
				return BadRequest("Error al crearun producto");
			}

			return Ok(resultado);
		}
	}
}
