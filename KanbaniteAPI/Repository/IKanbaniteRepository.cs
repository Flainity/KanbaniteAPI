using KanbaniteAPI.Entity;

namespace KanbaniteAPI.Repository;

public interface IKanbaniteRepository<T> where T : class
{
    IEnumerable<T> List();
    Task<IEnumerable<T>> ListAsync();
    T? GetById(Guid entityId);

    void Insert(T entity);

    void Update(T entity);

    void Remove(Guid entityId);
    void Remove(T entity);

    void Save();
}