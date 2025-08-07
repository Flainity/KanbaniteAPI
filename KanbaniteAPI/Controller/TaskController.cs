using System.Net;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Controller;

[ApiController]
[Route("task")]
public class TaskController(IKanbaniteRepository<TaskItem> taskRepository) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("List Tasks")]
    [EndpointDescription("Lists all tasks currently in the system")]
    public async Task<KanbaniteResponse<List<TaskDetailDto>>> List()
    {
        var tasks = await taskRepository.ListAsync();

        return this.SendApiResponse(tasks.Adapt<List<TaskDetailDto>>());
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get Task")]
    [EndpointDescription("Returns a single task by its ID")]
    public async Task<KanbaniteResponse<TaskDetailDto>> Get([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var guid))
            return this.SendApiError<TaskDetailDto>(["Invalid ID Format"], "The format of the id is not a valid GUID.");
        
        var task = await taskRepository.GetByIdAsync(Guid.Parse(id));

        return task.IsSome 
            ? this.SendApiResponse(task.Case.Adapt<TaskDetailDto>()) 
            : this.SendApiError<TaskDetailDto>(["Not found"], "Task does not exist", HttpStatusCode.NotFound);
    }

    [HttpPost]
    [EndpointSummary("Create Task")]
    [EndpointDescription("Creates a new task")]
    public KanbaniteResponse<TaskDetailDto> Create([FromBody] CreateTaskDto request)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            ProjectId = request.ProjectId,
            TaskStateId = request.TaskStateId
        };
        
        taskRepository.Insert(task);
        taskRepository.Save();

        return this.SendApiResponse(task.Adapt<TaskDetailDto>());
    }
}