﻿namespace KanbaniteAPI.Domain.Project;

public class ProjectDto
{
    public required string Name { get; set; } = string.Empty;
    public required string Shorthand { get; set; } = string.Empty;
}