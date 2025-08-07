using KanbaniteAPI.Data;
using KanbaniteAPI.Service;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Repository;

[AutoRegisterService(ServiceLifetimeType.Scoped)]
public class KanbaniteRepository<T>(KanbaniteDbContext context) : IKanbaniteRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public IEnumerable<T> List()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Option<T>> GetByIdAsync(Guid entityId)
    {
        return await _dbSet.FindAsync(entityId);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async Task RemoveAsync(Guid entityId)
    {
        var entity = await _dbSet.FindAsync(entityId);

        if (entity is null) return;

        _dbSet.Remove(entity);
    }

    public Task RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public void Save()
    {
        context.SaveChanges();
    }
}