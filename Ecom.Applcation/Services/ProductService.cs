using Ecom.Applcation.DTOs;
using Ecom.Applcation.Interfaces;
using Ecom.Applcation.Mappers;
using Ecom.Core.Entities.Product;
using Ecom.Core.Exceptions;
using Ecom.Core.Interfaces;

namespace Ecom.Applcation.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _work;
		private readonly IImageService _imageService;
		public ProductService(IUnitOfWork work, IImageService imageService)
		{
			_work = work;
			_imageService = imageService;
		}

		#region Get_Product
		public async Task<IReadOnlyList<ProductResponse>> GetAllProductsAsync()
		{
			IReadOnlyList<Product> products = await _work.Products.GetAllAsync(x => x.Category, x => x.ProductImages);
			return products.Select(p => p.ToResponse()).ToList();
		}

		public async Task<ProductResponse> GetProductByIdAsync(int id)
		{
			Product? product = await _work.Products.GetByIdAsync(id, x => x.Category, x => x.ProductImages);
			if (product == null)
				throw new NotFoundException(nameof(Product));

			return product.ToResponse();
		}
		#endregion

		public async Task<ProductResponse> AddProductAsync(AddProductRequest request)
		{
			Product product = request.ToEntity();
			List<Photo> photos = new List<Photo>();

			// Add the product to populate it's id
			await _work.Products.AddAsync(product);

			// To save the product to get the id
			await _work.SaveChangesAsync();

			// Uploading images and adding its url
			foreach (var file in request.PhotoFiles)
			{
				string photoUrl = await _imageService.SaveImageAsync(file, product.Id.ToString()); // Path: /uploads/images/{productId}/
				Photo photo = new Photo
				{
					Url = photoUrl,
					ProductId = product.Id,
				};
				photos.Add(photo);
			}

			// 
			await _work.Photos.AddRangeAsync(photos);
			
			// To save images
			await _work.SaveChangesAsync();


			// Make the response and return it
			Product? productFromDB = await _work.Products.GetByIdAsync(product.Id, x => x.Category, x => x.ProductImages);
			if (productFromDB == null)
				throw new NotFoundException("Product doesn't exist");

			return productFromDB.ToResponse();
		}

		public async Task<ProductResponse> UpdateProductAsync(int id, UpdateProductRequest request)
		{
			// Find Product
			Product? product = await _work.Products.GetByIdAsync(id, x => x.ProductImages); // Don't load category navigation prop because you will update the forign key
			List<Photo> photos = new List<Photo>();

			if (product == null)
				throw new NotFoundException("Product not found");

			// Apply the updates to the product
			request.ApplyTo(product);

			//_work.Products.Update(product);

			// Delete the old images before adding the new ones
			// Remove the files
			foreach (var photo in product.ProductImages)
				_imageService.DeleteImage(photo.Url);

			// Remove from database
			_work.Photos.RemoveRange(photos);

			// Adding the new images
			foreach (var file in request.PhotoFiles)
			{
				string photoUrl = await _imageService.SaveImageAsync(file, product.Id.ToString());
				Photo photo = new Photo
				{
					Url = photoUrl,
					ProductId = product.Id,
				};
				photos.Add(photo);
			}

			

			await _work.Photos.AddRangeAsync(photos);
			await _work.SaveChangesAsync();


			Product? productFromDB = await _work.Products.GetByIdAsync(product.Id, x => x.Category, x => x.ProductImages);

			return productFromDB.ToResponse();
		}

		public async Task DeleteProductAsync(int id)
		{
			Product? product = await _work.Products.GetByIdAsync(id, x => x.ProductImages);
			if (product == null)
				throw new NotFoundException("Product not found");

			foreach (var image in product.ProductImages)
				_imageService.DeleteImage(image.Url);

			var imagesDirectory = Path.Combine("wwwroot", "uploads", "images", id.ToString());
			if (Directory.Exists(imagesDirectory))
				Directory.Delete(imagesDirectory, true);

			//_work.Photos.RemoveRange(product.ProductImages); // No need for mannual deletion, it will be deleted automatic
			_work.Products.Delete(product);

			await _work.SaveChangesAsync();
		}
	}
}
