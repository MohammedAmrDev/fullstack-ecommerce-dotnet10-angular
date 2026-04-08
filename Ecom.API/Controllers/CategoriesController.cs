using Ecom.Applcation.DTOs;
using Ecom.Applcation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
	public class CategoriesController : BaseController
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _categoryService.GetCategoriesAsync();
			return Ok(categories);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			CategoryDTO category = await _categoryService.GetCategoryByIdAsync(id);
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
		{
			CategoryDTO category = await _categoryService.AddCategoryAsync(categoryDTO);
			return Ok(category);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return NoContent();
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDTO)
		{
			CategoryDTO category = await _categoryService.UpdateCategoryAsync(id, categoryDTO);
			return Ok(category);
		}
	}
}
