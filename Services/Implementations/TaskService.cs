using todo_backend.Data.Repository.Interfaces;
using todo_backend.Models;
using todo_backend.Services.Interfaces;
using todo_backend.Utils.Reponses;

namespace todo_backend.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository repo)
        {
            _taskRepository = repo;
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            var allowedStatuses = new[] { "pending", "inProgress", "completed" };
            if (!allowedStatuses.Contains(task.Status))
            {
                task.Status = "pending";
            }

            await _taskRepository.AddTask(task);
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null) return null;

            return task;
        }

        public async Task<IEnumerable<TaskItem>?> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<Response> UpdateTaskAsync(TaskItem taskItem, Guid id)
        {
            if (id != taskItem.Id) return new Response(false, "Task ID mismatch.");

            var task = await _taskRepository.GetTaskById(id);

            if (task == null) return new Response(false, "Task not found.");

            task.Title = taskItem.Title;
            task.Description = taskItem.Description;
            task.Status = taskItem.Status;
            task.CreatedAt = DateTime.UtcNow;

            await _taskRepository.UpdateTask(task);

            return new Response(true, "Ok", task);
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null)
                return false;

            await _taskRepository.DeleteTask(task.Id);
            return true;
        }
    }
}
