using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace ModernToDoApp.Services
{
    public class ToDoItemService
    {
        private readonly HttpClient _httpClient;

        public ToDoItemService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ToDoItemService");
        }

        public async Task<ToDoItem[]> GetDutiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<ToDoItem[]>("api/duties");
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoItem>($"api/duties/{id}");
        }

        public async Task CreateToDoItemAsync(ToDoItem duty)
        {
            await _httpClient.PostAsJsonAsync("api/duties", duty);
        }

        public async Task UpdateToDoItemAsync(ToDoItem duty)
        {
            await _httpClient.PutAsJsonAsync($"api/duties/{duty.Id}", duty);
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/duties/{id}");
        }
    }
}
