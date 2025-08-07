namespace KanbaniteAPI.Domain.Task;

public class TaskDetailDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Guid? ProjectId { get; set; }
    public Guid? TaskStateId { get; set; }
}