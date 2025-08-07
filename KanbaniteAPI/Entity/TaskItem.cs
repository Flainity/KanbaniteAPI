using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KanbaniteAPI.Entity;

[Table("tasks")]
public class TaskItem : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    [ForeignKey("Project")] 
    public Guid? ProjectId { get; set; }

    [ForeignKey("TaskState")]
    public Guid? TaskStateId { get; set; } = Guid.Parse("5565ef4f-0b8f-4f0b-88f4-c5211f367543");
    
    public Project Project { get; set; } = null!;
    public TaskState TaskState { get; set; } = null!;
}