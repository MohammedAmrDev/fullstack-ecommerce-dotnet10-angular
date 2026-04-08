using Ecom.Applcation.DTOs;
using Ecom.Applcation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
	public class ProductsController : BaseController
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IReadOnlyList<ProductResponse> products = await _productService.GetAllProductsAsync();
			return Ok(products);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			ProductResponse product = await _productService.GetProductByIdAsync(id);
			return Ok(product);
		}

		[HttpPost]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Add(AddProductRequest request)
		{
			ProductResponse response = await _productService.AddProductAsync(request);
			return Ok(response);
		}

		[HttpPut("{id:int}")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> Update(int id, UpdateProductRequest request)
		{
			ProductResponse response = await _productService.UpdateProductAsync(id, request);
			return Ok(response);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _productService.DeleteProductAsync(id);
			return NoContent();
		}
	}
}
