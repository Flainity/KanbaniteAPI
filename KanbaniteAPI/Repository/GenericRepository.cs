using KanbaniteAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Repository;

public class GenericRepository<T>(KanbaniteDbContext context) : IGenericRepository<T>
    where T : class
{
    private readonly KanbaniteDbContext _context = context;
    private readonly DbSet<T> _databaseSet = context.Set<T>();
    
    public async Task InsertAsync(T entity)
    {
        await _databaseSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task<List<T>> GetAllAsync(bool tracked = true)
    {
        IQueryable<T> query = _databaseSet;

        if (!tracked) query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _databaseSet.Update(entity);
        await SaveAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _databaseSet.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}