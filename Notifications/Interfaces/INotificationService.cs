using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Notifications.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllAsync();

        Task<Notification?> GetByIdAsync(int notificationId);

        Task<IEnumerable<Notification>> GetByCustomerAsync(int customerId);

        Task<IEnumerable<Notification>> GetUnreadAsync(int customerId);

        Task<Notification> CreateAsync(Notification notification);

        Task<bool> MarkAsReadAsync(int notificationId);

        Task<bool> UpdateAsync(int notificationId, Notification notification);

        Task<bool> DeleteAsync(int notificationId);
    }
}
