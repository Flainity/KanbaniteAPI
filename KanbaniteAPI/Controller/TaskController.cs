using KanbaniteAPI.Entity;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Controller;

[ApiController]
[Route("task")]
public class TaskController(ILogger<TaskController> logger, IKanbaniteRepository<TaskItem> taskRepository) : ControllerBase
{
    private readonly ILogger<TaskController> _logger = logger;

    [HttpGet(Name = "GetTasks")]
    public IEnumerable<TaskItem> Get()
    {
        return taskRepository.List();
    }
    
    [HttpPost(Name = "CreateTask")]
    public TaskItem Post([FromBody] TaskDto taskDto)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = taskDto.Title,
            Description = taskDto.Description
        };
        
        taskRepository.Insert(task);
        taskRepository.Save();

        return task;
    }
}