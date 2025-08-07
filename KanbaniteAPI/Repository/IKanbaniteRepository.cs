using KanbaniteAPI.Entity;
using LanguageExt;

namespace KanbaniteAPI.Repository;

public interface IKanbaniteRepository<T> where T : class
{
    IEnumerable<T> List();
    Task<IEnumerable<T>> ListAsync();
    Task<Option<T>> GetByIdAsync(Guid entityId);

    void Insert(T entity);

    void Update(T entity);

    Task RemoveAsync(Guid entityId);
    Task RemoveAsync(T entity);

    void Save();
}