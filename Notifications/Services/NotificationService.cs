using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.Interfaces;

namespace Marketplacesellerportal.Notifications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Notification?> GetByIdAsync(int notificationId)
            => await _repository.GetByIdAsync(notificationId);

        public async Task<IEnumerable<Notification>> GetByCustomerAsync(int customerId)
            => await _repository.GetByCustomerAsync(customerId);

        public async Task<IEnumerable<Notification>> GetUnreadAsync(int customerId)
            => await _repository.GetUnreadAsync(customerId);

        public async Task<Notification> CreateAsync(Notification notification)
        {
            notification.CreatedDate = DateTime.Now;
            notification.IsRead = false;

            await _repository.AddAsync(notification);
            await _repository.SaveChangesAsync();

            return notification;
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);

            if (notification == null)
                return false;

            notification.IsRead = true;

            await _repository.UpdateAsync(notification);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int notificationId, Notification notification)
        {
            var existing = await _repository.GetByIdAsync(notificationId);

            if (existing == null)
                return false;

            existing.Title = notification.Title;
            existing.Message = notification.Message;
            existing.CustomerId = notification.CustomerId;
            existing.IsRead = notification.IsRead;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int notificationId)
        {
            var existing = await _repository.GetByIdAsync(notificationId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(notificationId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
