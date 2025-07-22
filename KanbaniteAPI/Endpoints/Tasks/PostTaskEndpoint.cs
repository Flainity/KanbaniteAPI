using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Endpoints.Tasks;

public class PostTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : Endpoint<TaskDto, KanbaniteResponse<TaskItem>>
{
    public override void Configure()
    {
        Post("/task/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TaskDto req, CancellationToken ct)
    {
        var task = new Entity.TaskItem
        {
            Id = Guid.NewGuid(),
            Title = req.Title,
            Description = req.Description
        };
        
        taskRepository.Insert(task);
        taskRepository.Save();

        await this.SendApiResponseAsync(task);
    }
}