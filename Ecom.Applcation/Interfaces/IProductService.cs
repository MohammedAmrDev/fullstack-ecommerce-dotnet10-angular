using Ecom.Applcation.DTOs;

namespace Ecom.Applcation.Interfaces
{
	public interface IProductService
	{
		Task<IReadOnlyList<ProductResponse>> GetAllProductsAsync();
		Task<ProductResponse> GetProductByIdAsync(int id);
		Task<ProductResponse> AddProductAsync(AddProductRequest request);
		Task<ProductResponse> UpdateProductAsync(int id, UpdateProductRequest request);

		Task DeleteProductAsync(int id);
	}
}
