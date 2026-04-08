using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name).HasMaxLength(30);
			builder.Property(p => p.Description).HasMaxLength(200);
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
			builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");
			builder.HasData([
				new Product() { Id = 1, Name = "Redmi 12", Description = "Phone description", Price = 7000, CategoryId = 1 },
			]);
		}
	}
}
