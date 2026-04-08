using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Applcation.DTOs
{
	public record ProductResponse
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public IReadOnlyList<string> ProductImagesNames { get; set; } = [];
	}

	public record AddProductRequest
	{
		[Required(ErrorMessage = "Nams is required")]
		[MaxLength(30, ErrorMessage = "Name shouldn't be more than 30 characters")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description is required")]
		[MaxLength(80, ErrorMessage = "Description shouldn't be more than 80 characters")]
		public string Description {  get; set; } = string.Empty;

		[Required(ErrorMessage = "Price is required")]
		public decimal? Price {  get; set; }
		public decimal? OldPrice {  get; set; }

		[Required(ErrorMessage = "Category is required")]
		public int CategoryId {  get; set; }

		[MinLength(1, ErrorMessage = "You must at least have one photo")]
		public FormFileCollection PhotoFiles { get; set; } = [];
	}

	public record UpdateProductRequest
	{
		[Required(ErrorMessage = "Nams is required")]
		[MaxLength(30, ErrorMessage = "Name shouldn't be more than 30 characters")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description is required")]
		[MaxLength(80, ErrorMessage = "Description shouldn't be more than 80 characters")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Price is required")]
		public decimal Price { get; set; }
		public decimal? OldPrice { get; set; }

		[Required(ErrorMessage = "Category is required")]
		public int CategoryId { get; set; }

		[MinLength(1, ErrorMessage = "You must at least have one photo")]
		public FormFileCollection PhotoFiles { get; set; } = [];
	}
}
