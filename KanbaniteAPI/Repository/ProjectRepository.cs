using KanbaniteAPI.Data;
using KanbaniteAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Repository;

public class ProjectRepository(KanbaniteDbContext context) : IKanbaniteRepository<Project>
{
    public IEnumerable<Project> List()
    {
        return context.Projects.ToList();
    }

    public Project? GetById(Guid entityId)
    {
        return context.Projects.Find(entityId);
    }

    public void Insert(Project entity)
    {
        context.Projects.Add(entity);
    }

    public void Update(Project entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(Guid entityId)
    {
        var project = context.Projects.Find(entityId);

        if (project == null) return;

        context.Projects.Remove(project);
    }

    public void Remove(Project entity)
    {
        context.Projects.Remove(entity);
    }

    public void Save()
    {
        context.SaveChanges();
    }
}