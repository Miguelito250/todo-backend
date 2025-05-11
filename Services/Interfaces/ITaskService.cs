using todo_backend.Models;
using todo_backend.Utils.Reponses;

namespace todo_backend.Services.Interfaces
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskItem task);
        Task<TaskItem?> GetTaskByIdAsync(Guid taskId);
        Task<IEnumerable<TaskItem>?> GetAllTasksAsync();
        Task<Response> UpdateTaskAsync(TaskItem task, Guid id);
        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}
