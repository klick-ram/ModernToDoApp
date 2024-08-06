using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await Task.FromResult(_users.Find(u => u.Id == id));
        }

        public async Task AddUserAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = _users.Find(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            await Task.CompletedTask;
        }
    }
}
