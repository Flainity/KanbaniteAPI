using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KanbaniteAPI.Entity;

[Table("projects")]
public class Project : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Shorthand { get; set; }
    public ICollection<TaskItem> Tasks { get; } = new List<TaskItem>();
}