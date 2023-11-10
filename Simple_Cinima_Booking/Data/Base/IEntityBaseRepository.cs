using System.Linq.Expressions;

namespace Simple_Cinima_Booking.Data.Base
{
	public interface IEntityBaseRepository<T> where T: class, IEntityBase, new() 
	{
		Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpression);
        Task<T> GetByIdAsync(int id);
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		Task UpdateAsync(int id,T entity);
	}
}
