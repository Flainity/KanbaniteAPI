using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.TaskState;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;

namespace KanbaniteAPI.Endpoints.TaskStates;

public class ListTaskStates(IKanbaniteRepository<TaskState> taskStateRepository) : EndpointWithoutRequest<KanbaniteResponse<List<TaskStateDto>>>
{
    public override void Configure()
    {
        Get("/task/state");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var states = await taskStateRepository.ListAsync();

        var adaption = states.Adapt<List<TaskStateDto>>();
        
        await this.SendApiResponseAsync(adaption);
    }
}