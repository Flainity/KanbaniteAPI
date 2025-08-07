namespace KanbaniteAPI.Domain.TaskState;

public class CreateTaskStateDto
{
    public string Name { get; set; } = string.Empty;
    public Guid? ProjectId { get; set; } = null!;
}