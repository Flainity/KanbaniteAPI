using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Endpoints.Tasks;

[Tags("Tasks")]
public class PostTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : Endpoint<TaskDto, KanbaniteResponse<TaskItem>>
{
    public override void Configure()
    {
        Post("/task");
        Description(x => x
            .WithDescription("Creates a new task object.")
            .WithDisplayName("New Name")
        );
        Tags("Tasks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TaskDto req, CancellationToken ct)
    {
        var task = new TaskItem
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