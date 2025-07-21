using System.Linq.Expressions;

namespace KanbaniteAPI.Repository;

public interface IGenericRepository<T> where T : class
{
    Task InsertAsync(T entity);
    Task<List<T>> GetAllAsync(bool tracked = true);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task SaveAsync();
}