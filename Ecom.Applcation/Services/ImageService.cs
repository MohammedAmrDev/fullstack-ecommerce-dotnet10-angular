using Ecom.Applcation.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Applcation.Services
{
	public class ImageService : IImageService
	{
		public async Task<string> SaveImageAsync(IFormFile file, string folder)
		{
			List<string> extensions = [".jpg", ".png"];
			var extension = Path.GetExtension(file.FileName).ToLower();

			if (!extensions.Contains(extension))
				throw new ValidationException("Unsupported extension file");

			if (file.Length > 1024 * 1024 * 5)
				throw new ValidationException("Image size is larger than 5 MB");

			var uploadPath = Path.Combine("wwwroot", "uploads", "images", folder);
			if (!Directory.Exists(uploadPath))
				Directory.CreateDirectory(uploadPath);

			//var imageFile = Path.Combine(uploadPath, Path.GetFileName(file.FileName));
			var imageFile = Path.Combine(uploadPath, file.FileName);
			await using var stream = new FileStream(imageFile, FileMode.Create);
			await file.CopyToAsync(stream);

			return $"uploads/images/{folder}/{file.FileName}";
		}

		public void DeleteImage(string imageUrl)
		{
			var path = Path.Combine("wwwroot", imageUrl.TrimEnd('/'));
			if (File.Exists(path))
				File.Delete(path);
		}
	}
}
