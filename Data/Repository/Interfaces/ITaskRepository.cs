using todo_backend.Models;

namespace todo_backend.Data.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>?> GetAllTasks(Guid userId);
        Task<TaskItem?> GetTaskById(Guid id);
        Task AddTask(TaskItem task);
        Task UpdateTask(TaskItem task);
        Task DeleteTask(Guid id);
    }
}
