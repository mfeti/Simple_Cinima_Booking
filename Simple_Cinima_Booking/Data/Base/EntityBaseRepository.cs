using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Simple_Cinima_Booking.Models;
using System.Linq.Expressions;

namespace Simple_Cinima_Booking.Data.Base
{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDbContext _context;
		public EntityBaseRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}
		
		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var data = await _context.Set<T>().ToListAsync();
			return data;
		}

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpression)
        {
			IQueryable<T> query = _context.Set<T>();
			query = includeExpression.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));
			return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
		{
			var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
			return result;
		}
		


		public async Task UpdateAsync(int id, T entity)
		{
			EntityEntry entityEntry = _context.Entry<T>(entity);
			entityEntry.State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
		

	}
}
