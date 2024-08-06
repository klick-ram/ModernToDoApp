using Microsoft.AspNetCore.Mvc;
using SharedDAL.Models;
using SharedDAL.Repositories;

namespace UserTaskService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutyController : ControllerBase
    {
        private readonly IDutyRepository _dutyRepository;

        public DutyController(IDutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duty>>> GetAllTasks()
        {
            var tasks = await _dutyRepository.GetAllDutiesAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Duty>> GetTaskById(int id)
        {
            var task = await _dutyRepository.GetDutyByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(Duty task)
        {
            await _dutyRepository.AddDutyAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, Duty task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _dutyRepository.UpdateDutyAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _dutyRepository.DeleteDutyAsync(id);
            return NoContent();
        }
    }
}
