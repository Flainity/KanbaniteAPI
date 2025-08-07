namespace KanbaniteAPI.Domain.TaskState;

public class TaskStateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? ProjectId { get; set; } = null!;
}