using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Entity;

[Table("tasks")]
public class TaskItem
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [ForeignKey("Project")] public Guid? ProjectId { get; set; } = null!;
    
    public Project Project { get; set; } = null!;
}