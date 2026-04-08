using Microsoft.AspNetCore.Http;

namespace Ecom.Applcation.Interfaces
{
	public interface IImageService
	{
		Task<string> SaveImageAsync(IFormFile file, string folder);
		void DeleteImage(string imageUrl);
	}
}
