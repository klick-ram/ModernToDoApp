using System.Collections.Generic;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace SharedDAL.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _tasks = new List<ToDoItem>();

        public async Task<IEnumerable<ToDoItem>> GetAllDutiesAsync()
        {
            return await Task.FromResult(_tasks);
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await Task.FromResult(_tasks.Find(t => t.Id == id));
        }

        public async Task AddToDoItemAsync(ToDoItem task)
        {
            _tasks.Add(task);
            await Task.CompletedTask;
        }

        public async Task UpdateToDoItemAsync(ToDoItem task)
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

        public async Task DeleteToDoItemAsync(int id)
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
