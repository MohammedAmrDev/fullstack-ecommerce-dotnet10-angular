using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public ICategoryRepository Categories { get; }

		public IProductRepository Products { get; }

		public IPhotoRepository Photos { get; }

		private AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			Categories = new CategoryRepository(_context);
			Products = new ProductRepository(_context);
			Photos = new PhotoRepository(_context);
		}
	}
}
