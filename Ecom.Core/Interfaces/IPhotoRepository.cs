using Ecom.Core.Entities.Product;

namespace Ecom.Core.Interfaces
{
	public interface IPhotoRepository : IGenericRepository<Photo, int>
	{
		Task AddRangeAsync(IEnumerable<Photo> photos);
		void RemoveRange(IEnumerable<Photo> photos);
	}
}
