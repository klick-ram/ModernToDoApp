using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Repositories
{
    public class NotificationRepository
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await Task.FromResult(_notifications);
        }

        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await Task.FromResult(_notifications.Find(n => n.Id == id));
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _notifications.Add(notification);
            await Task.CompletedTask;
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            var existingNotification = _notifications.Find(n => n.Id == notification.Id);
            if (existingNotification != null)
            {
                existingNotification.Message = notification.Message;
                existingNotification.Date = notification.Date;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notification = _notifications.Find(n => n.Id == id);
            if (notification != null)
            {
                _notifications.Remove(notification);
            }
            await Task.CompletedTask;
        }
    }
}
