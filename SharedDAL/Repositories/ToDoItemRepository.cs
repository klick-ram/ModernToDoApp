using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedDAL.Data;
using SharedDAL.Models;

namespace SharedDAL.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {        
        private readonly ToDoItemContext _context;
        public ToDoItemRepository(ToDoItemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDoItemsAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddToDoItemAsync(ToDoItem task)
        {
            _context.ToDoItems.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateToDoItemAsync(ToDoItem task)
        {
            _context.ToDoItems.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            var task = await _context.ToDoItems.FindAsync(id);
            if (task != null)
            {
                _context.ToDoItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
