using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ModernToDoApp.Models;

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

        public async Task<HttpResponseMessage> GetUserAsync(User user)
        {
            //return await _httpClient.GetFromJsonAsync<User>($"api/auth/login", user);
           return await _httpClient.PostAsJsonAsync($"api/auth/login", user);           

        }

        public async Task<HttpResponseMessage> CreateUserAsync(User user)
        {
            return await _httpClient.PostAsJsonAsync($"api/auth/register", user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _httpClient.PutAsJsonAsync($"api/users/{user.Username}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/users/{id}");
        }
    }
}
