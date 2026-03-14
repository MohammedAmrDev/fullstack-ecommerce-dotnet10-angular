namespace Ecom.Core.Interfaces
{
	public interface IUnitOfWork
	{
		public ICategoryRepository Categories { get; }
		public IProductRepository Products { get; }
		public IPhotoRepository Photos { get; }
	}
}
