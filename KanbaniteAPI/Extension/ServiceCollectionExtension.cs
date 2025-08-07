using System.Reflection;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Repository;
using KanbaniteAPI.Service;

namespace KanbaniteAPI.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddKanbaniteServices(this IServiceCollection services)
    {
        return RegisterRepositories(services);
    }

    private static IServiceCollection RegisterRepositories(IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var entityTypes = assembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t));

        foreach (var entityType in entityTypes)
        {
            var repositoryInterface = typeof(IKanbaniteRepository<>).MakeGenericType(entityType);
            var repositoryImplementation = typeof(KanbaniteRepository<>).MakeGenericType(entityType);

            services.AddScoped(repositoryInterface, repositoryImplementation);
        }

        return services;
    }
}