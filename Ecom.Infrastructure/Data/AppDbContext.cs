using Ecom.Core.Entities.Product;
using Ecom.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Photo> Photos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.ApplyConfiguration(new ProductConfiguration());
			//modelBuilder.ApplyConfiguration(new CategoryConfiguration());

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
