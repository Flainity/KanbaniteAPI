using System.Net;
using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;

namespace KanbaniteAPI.Endpoints.Tasks;

public class GetTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository)
    : EndpointWithoutRequest<KanbaniteResponse<TaskDetailDto>>
{
    public override void Configure()
    {
        Get("/task/{id}");
        Summary(s => s.Summary = "A summary");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var task = await taskRepository.GetByIdAsync(id);

        await task.Match(
            async t => { await this.SendApiResponseAsync(t.Adapt<TaskDetailDto>()); },
            async () => { await this.SendApiErrorAsync(["Not Found"], "Not found", HttpStatusCode.NotFound); });
    }
}