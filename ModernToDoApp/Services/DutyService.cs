using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace ModernToDoApp.Services
{
    public class DutyService
    {
        private readonly HttpClient _httpClient;

        public DutyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DutyService");
        }

        public async Task<Duty[]> GetDutiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<Duty[]>("api/duties");
        }

        public async Task<Duty> GetDutyByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Duty>($"api/duties/{id}");
        }

        public async Task CreateDutyAsync(Duty duty)
        {
            await _httpClient.PostAsJsonAsync("api/duties", duty);
        }

        public async Task UpdateDutyAsync(Duty duty)
        {
            await _httpClient.PutAsJsonAsync($"api/duties/{duty.Id}", duty);
        }

        public async Task DeleteDutyAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/duties/{id}");
        }
    }
}
