using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Endpoints.Tasks;

public class GetTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : EndpointWithoutRequest<KanbaniteResponse<List<TaskItem>>>
{
    public override void Configure()
    {
        Get("/task");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var tasks = await taskRepository.ListAsync();

        await this.SendApiResponseAsync(tasks);
    }
}