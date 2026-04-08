using Ecom.Applcation.Interfaces;
using Ecom.Applcation.Services;
using Microsoft.Extensions.DependencyInjection; // Why this namespace does not work until i made a reference to the core project ?

namespace Ecom.Applcation
{
	public static class ApplicationRegistration
	{
		public static IServiceCollection ApplicationConfiguration(this IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IImageService, ImageService>();

			return services;
		}
	}
}
