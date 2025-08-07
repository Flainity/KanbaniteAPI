using System.Net;
using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Endpoints.Tasks;

[Tags("Tasks")]
public class UpdateTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : Endpoint<PatchTaskDto, KanbaniteResponse<TaskItem>>
{
    public override void Configure()
    {
        Patch("/task/{id}");
        Tags("Tasks");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(PatchTaskDto req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var task = await taskRepository.GetByIdAsync(id);

        await task.Match(async t =>
        {
            if (req.Title != null) t.Title = req.Title;
            if (req.Description != null) t.Description = req.Description;
            if (req.TaskStateId != null) t.TaskStateId = req.TaskStateId;

            taskRepository.Update(t);
            taskRepository.Save();

            await this.SendApiResponseAsync(task);
        }, async () => { await this.SendApiErrorAsync(["Not found"], $"Task with id {id} does not exist.", HttpStatusCode.NotFound); });
    }
}