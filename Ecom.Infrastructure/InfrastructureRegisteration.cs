using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Infrastructure
{
	public static class InfrastructureRegisteration
	{
		public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});
			return services;
		}
	}
}
