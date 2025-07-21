using KanbaniteAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Data;

public class KanbaniteDbContext(DbContextOptions<KanbaniteDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}