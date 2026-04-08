namespace Ecom.Core.Entities.Product
{
	public class Photo : BaseEntity<int>
	{
		public string Url { get; set; } = string.Empty;
		public int ProductId { get; set; }
	}
}
