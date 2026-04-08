using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repositories
{
	public class PhotoRepository : GenericRepository<Photo, int>, IPhotoRepository
	{
		private readonly AppDbContext _context;
		public PhotoRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task AddRangeAsync(IEnumerable<Photo> photos)
		{
			await _context.AddRangeAsync(photos);
		}

		public void RemoveRange(IEnumerable<Photo> photos)
		{
			_context.RemoveRange(photos);
		}
	}
}
