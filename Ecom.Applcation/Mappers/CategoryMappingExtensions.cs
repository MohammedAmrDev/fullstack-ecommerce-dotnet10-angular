using Ecom.Applcation.DTOs;
using Ecom.Core.Entities.Product;

namespace Ecom.Applcation.Mappers
{
	public static class CategoryMappingExtensions
	{
		public static Category ToEntity(this CategoryDTO categoryDTO)
		{
			return new Category
			{
				Name = categoryDTO.Name,
				Description = categoryDTO.Description,
			};
		}

		public static Category ApplyTo(this CategoryDTO categoryDTO, Category category)
		{
			category.Name = categoryDTO.Name;
			category.Description = categoryDTO.Description;
			return category;
		}

		public static CategoryDTO ToDto(this Category category)
		{
			return new CategoryDTO(category.Name, category.Description);
		}
	}
}
