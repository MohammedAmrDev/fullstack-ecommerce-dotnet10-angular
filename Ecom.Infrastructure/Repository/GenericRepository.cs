using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecom.Infrastructure.Repository
{
	public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
	{
		private readonly AppDbContext _context;
		public GenericRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TKey id)
		{
			TEntity? entity = await _context.Set<TEntity>().FindAsync(id);
			if (entity != null)
				_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<TEntity>> GetAllAsync() => 
			await _context.Set<TEntity>().AsNoTracking().ToListAsync();

		public async Task<IReadOnlyList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> entities = _context.Set<TEntity>().AsNoTracking();
			foreach (var include in includes)
				entities = entities.Include(include);
			return await entities.ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(TKey id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> entities = _context.Set<TEntity>().AsNoTracking();
			foreach (var include in includes)
				entities = entities.Include(include);
			return await entities.FirstOrDefaultAsync(e => EF.Property<TKey>(e, "Id")!.Equals(id));
		}

		public Task UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			return _context.SaveChangesAsync();
		}
	}
}
