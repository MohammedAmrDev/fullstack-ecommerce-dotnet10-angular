using Ecom.Applcation.DTOs;
using Ecom.Applcation.Interfaces;
using Ecom.Applcation.Mappers;
using Ecom.Core.Entities.Product;
using Ecom.Core.Exceptions;
using Ecom.Core.Interfaces;

namespace Ecom.Applcation.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _work;

		public CategoryService(IUnitOfWork work)
		{
			_work = work;
		}

		public async Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync()
		{
			IReadOnlyList<Category> categories = await _work.Categories.GetAllAsync();
			return categories.Select(c => c.ToDto()).ToList();
		}

		public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
		{
			var category = await _work.Categories.GetByIdAsync(id);
			if (category == null)
				throw new NotFoundException(nameof(Category));

			return category.ToDto();
		}

		public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
		{
			Category category = categoryDTO.ToEntity();
			await _work.Categories.AddAsync(category);

			await _work.SaveChangesAsync();

			return category.ToDto();
		}

		public async Task DeleteCategoryAsync(int id)
		{
			Category? category = await _work.Categories.GetByIdAsync(id);
			if (category == null)
				throw new NotFoundException(nameof(Category));

			_work.Categories.Delete(category);

			await _work.SaveChangesAsync();
		}

		public async Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
		{
			Category? category = await _work.Categories.GetByIdAsync(id);
			if (category == null)
				throw new NotFoundException(nameof(Category));

			categoryDTO.ApplyTo(category);
			_work.Categories.Update(category);

			await _work.SaveChangesAsync();

			return category.ToDto();
		}
	}
}
