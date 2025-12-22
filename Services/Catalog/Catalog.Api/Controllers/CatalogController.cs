using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CatalogController : ControllerBase
	{
		#region Ctor 

		private readonly IProductRepository _productRepository;
		private readonly ILogger<CatalogController> _logger;

		public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
		{
			_productRepository = productRepository;
			_logger = logger;
		}

		#endregion

		#region  Get Products

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
		{
			var products = await _productRepository.GetProducts();
			return Ok(products);
		}


		#endregion

		#region  Get Products By ID

		[HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Products>>> GetProducts(string id)
		{
			var products = await _productRepository.GetProducts(id);
			if(products == null)
			{
				_logger.LogError($"Product with id : {id} not found");
				return NotFound();
			}
			return Ok(products);
		}


		#endregion

		#region  Get Products By Category

		[HttpGet("[action]/{category}")]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Products>>> GetProductsByCategory(string category)
		{
			var products = await _productRepository.GetProductsByCategory(category);
			return Ok(products);
		}


		#endregion

		#region Create Product 

		[HttpPost]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Products>> CreateProduct([FromBody] Products product)
		{
			await _productRepository.CreateProduct(product);
			return CreatedAtRoute("GetProducts" , new { id = product.ID} , product);
		}

		#endregion

		#region Update Product 

		[HttpPut]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Products>> UpdateProduct([FromBody] Products product)
		{
			return Ok(await _productRepository.UpdateProduct(product));
		}

		#endregion

		#region Delete Product 

		[HttpDelete]
		[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<Products>> DeleteProduct(string id)
		{
			return Ok(await _productRepository.DeleteProduct(id));
		}

		#endregion
	}
}