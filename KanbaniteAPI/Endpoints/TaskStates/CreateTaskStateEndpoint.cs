using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.TaskState;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;

namespace KanbaniteAPI.Endpoints.TaskStates;

public class CreateTaskStateEndpoint(IKanbaniteRepository<TaskState> stateRepository) : Endpoint<CreateTaskStateDto, KanbaniteResponse<TaskStateDto>>
{
    public override void Configure()
    {
        Post("/task/state");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateTaskStateDto req, CancellationToken ct)
    {
        var task = new TaskState
        {
            Id = Guid.NewGuid(),
            Name = req.Name,
            ProjectId = req.ProjectId
        };
        
        stateRepository.Insert(task);
        stateRepository.Save();

        await this.SendApiResponseAsync(task.Adapt<TaskStateDto>());
    }
}