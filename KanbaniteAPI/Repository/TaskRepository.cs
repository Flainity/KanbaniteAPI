using KanbaniteAPI.Data;
using KanbaniteAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KanbaniteAPI.Repository;

public class TaskRepository(KanbaniteDbContext context) : IKanbaniteRepository<TaskItem>, IDisposable
{   
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<TaskItem> List()
    {
        return context.Tasks.ToList();
    }

    public TaskItem? GetById(Guid entityId)
    {
        return context.Tasks.Find(entityId);
    }

    public void Insert(TaskItem entity)
    {
        context.Tasks.Add(entity);
    }

    public void Update(TaskItem entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(Guid entityId)
    {
        var task = context.Tasks.Find(entityId);

        if (task == null) return;

        context.Tasks.Remove(task);
    }

    public void Remove(TaskItem entity)
    {
        context.Tasks.Remove(entity);
    }

    public void Save()
    {
        context.SaveChanges();
    }
}