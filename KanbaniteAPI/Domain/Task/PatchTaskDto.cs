using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Domain.Task;

public class PatchTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}