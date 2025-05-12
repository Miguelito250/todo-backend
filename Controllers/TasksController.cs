using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_backend.Models;
using todo_backend.Services.Interfaces;

namespace todo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _taskService.CreateTaskAsync(task);

            return Created();
        }

        [HttpGet]
        [Route("tasksUser/{userId:guid}")]
        public async Task<IActionResult> GetAllTasks(Guid userId)
        {
            var tasks = await _taskService.GetAllTasksAsync(userId);
            if (tasks == null) return NotFound();

            return Ok(tasks);
        }

        [HttpGet("{taskId:guid}")]
        public async Task<IActionResult> GetTaskById(Guid taskId)
        {
            var task = await _taskService.GetTaskByIdAsync(taskId);
            if (task == null) return NotFound();

            return Ok(task);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskItem task, Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _taskService.UpdateTaskAsync(task, id);
            if (!response.Status) return NotFound(response.StatusMessage);

            TaskItem taskToSend = (TaskItem)response.DataResponse!;

            return Ok(taskToSend);
        }

        [HttpDelete("{taskId:guid}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            var result = await _taskService.DeleteTaskAsync(taskId);
            return !result ? NotFound() : NoContent();
        }
    }
}
