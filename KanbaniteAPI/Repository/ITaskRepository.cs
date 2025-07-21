using KanbaniteAPI.Entity;

namespace KanbaniteAPI.Repository;

public interface ITaskRepository : IDisposable
{
    IEnumerable<TaskItem> GetTasks();
    TaskItem? GetTaskById(Guid taskId);

    void InsertTask(TaskItem task);

    void UpdateTask(TaskItem task);
    
    void DeleteTask(Guid taskId);
    void DeleteTask(TaskItem task);

    void Save();
}