using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Core.Entities.Product
{
	public class Photo : BaseEntity<int>
	{
		public string Name { get; set; }
		public int ProductId { get; set; }
		[ForeignKey(nameof(ProductId))]
		public virtual Product Product { get; set; }
	}
}
