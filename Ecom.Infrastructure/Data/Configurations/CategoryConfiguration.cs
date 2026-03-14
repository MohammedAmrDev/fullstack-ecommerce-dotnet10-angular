using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(30);
			builder.HasData([
				new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
				new Category { Id = 2, Name = "Accessories", Description = "Headphones, chargers and covers" },
				new Category { Id = 3, Name = "Books", Description = "Historical, education and Stories" },
			]);
		}
	}
}
