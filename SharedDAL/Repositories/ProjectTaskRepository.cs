using System.Collections.Generic;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace SharedDAL.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly List<ProjectTask> _tasks = new List<ProjectTask>();

        public async Task<IEnumerable<ProjectTask>> GetAllTasksAsync()
        {
            return await Task.FromResult(_tasks);
        }

        public async Task<ProjectTask> GetTaskByIdAsync(int id)
        {
            return await Task.FromResult(_tasks.Find(t => t.Id == id));
        }

        public async Task AddTaskAsync(ProjectTask task)
        {
            _tasks.Add(task);
            await Task.CompletedTask;
        }

        public async Task UpdateTaskAsync(ProjectTask task)
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
