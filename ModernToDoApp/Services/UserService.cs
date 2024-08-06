using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace ModernToDoApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("UserService");
        }

        public async Task<User[]> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<User[]>("api/users");
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/users/{id}");
        }

        public async Task CreateUserAsync(User user)
        {
            await _httpClient.PostAsJsonAsync("api/user", user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _httpClient.PutAsJsonAsync($"api/users/{user.Id}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/users/{id}");
        }
    }
}
