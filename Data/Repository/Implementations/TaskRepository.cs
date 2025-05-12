using Microsoft.EntityFrameworkCore;
using todo_backend.Data.Repository.Interfaces;
using todo_backend.Models;

namespace todo_backend.Data.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksManagerContext _context;
        public TaskRepository(TasksManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>?> GetAllTasks(Guid userId)
        {
            return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
        }

        async public Task<TaskItem?> GetTaskById(Guid id)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        async public Task AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        async public Task UpdateTask(TaskItem task)
        {

            var existingTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == task.Id);

            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.CreatedAt = task.CreatedAt;

                await _context.SaveChangesAsync();
            }
        }

        async public Task DeleteTask(Guid id)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
