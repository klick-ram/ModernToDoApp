using Microsoft.AspNetCore.Mvc;
using SharedDAL.Models;
using SharedDAL.Repositories;

namespace UserTaskService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
        {
            var toDoItems = await _toDoItemRepository.GetAllToDoItemsAsync();
            return toDoItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetTaskById(int id)
        {
            var task = await _toDoItemRepository.GetToDoItemByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(ToDoItem task)
        {
            await _toDoItemRepository.AddToDoItemAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, ToDoItem task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _toDoItemRepository.UpdateToDoItemAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _toDoItemRepository.DeleteToDoItemAsync(id);
            return NoContent();
        }
    }
}
