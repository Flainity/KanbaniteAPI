using KanbaniteAPI.Entity;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddKanbaniteServices(this IServiceCollection services)
    {
        services.AddScoped<IKanbaniteRepository<TaskItem>, TaskRepository>();
        services.AddScoped<IKanbaniteRepository<Project>, ProjectRepository>();

        return services;
    }
}