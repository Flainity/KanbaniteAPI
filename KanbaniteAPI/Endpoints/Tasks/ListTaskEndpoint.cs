using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;

namespace KanbaniteAPI.Endpoints.Tasks;

[Tags("Tasks")]
public class ListTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : EndpointWithoutRequest<KanbaniteResponse<List<TaskDto>>>
{
    public override void Configure()
    {
        Get("/task");
        Tags("Tasks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var tasks = await taskRepository.ListAsync();

        await this.SendApiResponseAsync(tasks.Adapt<List<TaskDto>>());
    }
}