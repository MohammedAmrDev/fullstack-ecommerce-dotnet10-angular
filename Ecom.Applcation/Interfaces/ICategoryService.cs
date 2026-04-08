using Ecom.Applcation.DTOs;

namespace Ecom.Applcation.Interfaces
{
	public interface ICategoryService
	{
		Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync();
		Task<CategoryDTO> GetCategoryByIdAsync(int id);
		Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO);
		Task DeleteCategoryAsync(int id);
		Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
	}
}
