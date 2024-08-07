using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Repositories
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllDutiesAsync();
        Task<ToDoItem> GetToDoItemByIdAsync(int id);
        Task AddToDoItemAsync(ToDoItem task);
        Task UpdateToDoItemAsync(ToDoItem task);
        Task DeleteToDoItemAsync(int id);
    }
}
