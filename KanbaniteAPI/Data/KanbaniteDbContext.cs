using KanbaniteAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Data;

public class KanbaniteDbContext(DbContextOptions<KanbaniteDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskState> TaskStates => Set<TaskState>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskState>().HasData(new TaskState
        {
            Id = Guid.Parse("5565ef4f-0b8f-4f0b-88f4-c5211f367543"),
            Name = "Open"
        });
    }
}