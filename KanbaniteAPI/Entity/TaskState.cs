using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbaniteAPI.Entity;

[Table("tasks_states")]
public class TaskState
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey("Project")]
    public Guid? ProjectId { get; set; } = null!;
    public Project Project { get; set; } = null!;
}