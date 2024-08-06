using System.Collections.Generic;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace SharedDAL.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly List<UserTask> _tasks = new List<UserTask>();

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            return await Task.FromResult(_tasks);
        }

        public async Task<UserTask> GetTaskByIdAsync(int id)
        {
            return await Task.FromResult(_tasks.Find(t => t.Id == id));
        }

        public async Task AddTaskAsync(UserTask task)
        {
            _tasks.Add(task);
            await Task.CompletedTask;
        }

        public async Task UpdateTaskAsync(UserTask task)
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

        public async Task DeleteTaskAsync(int id)
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
