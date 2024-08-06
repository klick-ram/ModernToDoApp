using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedDAL.Models;

namespace ModernToDoApp.Services
{
    public class NotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NotificationService");
        }

        public async Task<Notification[]> GetNotificationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Notification[]>("api/notifications");
        }

        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Notification>($"api/notifications/{id}");
        }

        public async Task CreateNotificationAsync(Notification notification)
        {
            await _httpClient.PostAsJsonAsync("api/notifications", notification);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _httpClient.PutAsJsonAsync($"api/notifications/{notification.Id}", notification);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/notifications/{id}");
        }
    }
}
