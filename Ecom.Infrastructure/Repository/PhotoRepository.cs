using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repository
{
	public class PhotoRepository : GenericRepository<Photo, int>, IPhotoRepository
	{
		public PhotoRepository(AppDbContext context) : base(context)
		{
		}
	}
}
