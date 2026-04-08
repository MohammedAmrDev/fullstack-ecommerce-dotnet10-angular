using System.Linq.Expressions;

namespace Ecom.Core.Interfaces
{
	public interface IGenericRepository<TEntity, TKey> where TEntity : class
	{
		Task<IReadOnlyList<TEntity>> GetAllAsync();
		Task<IReadOnlyList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
		Task<TEntity?> GetByIdAsync(TKey id);
		Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
