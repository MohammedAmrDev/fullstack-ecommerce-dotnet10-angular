using Ecom.Applcation.DTOs;
using Ecom.Core.Entities.Product;

namespace Ecom.Applcation.Mappers
{
	public static class ProductMappingExtensions
	{
		public static ProductResponse ToResponse(this Product product)
		{
			return new ProductResponse
			{
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				CategoryName = product.Category.Name, // Warning: You must load the data before using it
				ProductImagesNames = product.ProductImages.Select(p => p.Url).ToList(), // Warning: You must load the data before using it
			};
		}

		public static Product ToEntity(this AddProductRequest request)
		{
			return new Product
			{
				Name = request.Name,
				Description = request.Description,
				Price = request.Price.Value,
				OldPrice = request.OldPrice,
				CategoryId = request.CategoryId,
			};
		}

		public static void ApplyTo(this UpdateProductRequest request, Product product)
		{
			product.Name = request.Name;
			product.Description = request.Description;
			product.Price = request.Price;
			product.OldPrice = request.OldPrice;
			product.CategoryId = request.CategoryId;
			// The updation of images are not implemented here !
		}
	}
}
