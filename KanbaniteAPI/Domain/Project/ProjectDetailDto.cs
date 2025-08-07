namespace KanbaniteAPI.Domain.Project;

public class ProjectDetailDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Shorthand { get; set; } = string.Empty;
}