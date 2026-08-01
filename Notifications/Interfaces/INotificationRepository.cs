using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Notifications.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();

        Task<Notification?> GetByIdAsync(int notificationId);

        Task<IEnumerable<Notification>> GetByCustomerAsync(int customerId);

        Task<IEnumerable<Notification>> GetUnreadAsync(int customerId);

        Task AddAsync(Notification notification);

        Task UpdateAsync(Notification notification);

        Task DeleteAsync(int notificationId);

        Task SaveChangesAsync();
    }
}
