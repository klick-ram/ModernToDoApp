using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Repositories
{
    public interface IDutyRepository
    {
        Task<IEnumerable<Duty>> GetAllTasksAsync();
        Task<Duty> GetTaskByIdAsync(int id);
        Task AddTaskAsync(Duty task);
        Task UpdateTaskAsync(Duty task);
        Task DeleteTaskAsync(int id);
    }
}
