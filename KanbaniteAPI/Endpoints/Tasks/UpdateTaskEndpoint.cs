using System.Net;
using FastEndpoints;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;

namespace KanbaniteAPI.Endpoints.Tasks;

public class UpdateTaskEndpoint(IKanbaniteRepository<TaskItem> taskRepository) : Endpoint<PatchTaskDto, KanbaniteResponse<TaskItem>>
{
    public override void Configure()
    {
        Patch("/task/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(PatchTaskDto req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var task = taskRepository.GetById(id);

        if (task == null)
        {
            await this.SendApiErrorAsync(["Not found"], $"Task with id {id} does not exist.", HttpStatusCode.NotFound);
            return;
        }

        if (req.Title != null)
            task.Title = req.Title;
        
        if (req.Description != null)
            task.Description = req.Description;
        
        taskRepository.Update(task);
        taskRepository.Save();

        await this.SendApiResponseAsync(task);
    }
}