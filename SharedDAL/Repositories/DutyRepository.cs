using System.Collections.Generic;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace SharedDAL.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        private readonly List<Duty> _tasks = new List<Duty>();

        public async Task<IEnumerable<Duty>> GetAllDutiesAsync()
        {
            return await Task.FromResult(_tasks);
        }

        public async Task<Duty> GetDutyByIdAsync(int id)
        {
            return await Task.FromResult(_tasks.Find(t => t.Id == id));
        }

        public async Task AddDutyAsync(Duty task)
        {
            _tasks.Add(task);
            await Task.CompletedTask;
        }

        public async Task UpdateDutyAsync(Duty task)
        {
            var existingTask = _tasks.Find(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteDutyAsync(int id)
        {
            var task = _tasks.Find(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
            await Task.CompletedTask;
        }
    }
}
