using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repository
{
	public class ProductRepository : GenericRepository<Product, int>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{

		}
	}
}