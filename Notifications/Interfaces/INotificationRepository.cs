using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.DTOs;

namespace Marketplacesellerportal.Notifications.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();

        Task<Notification?> GetByIdAsync(
            int notificationId);

        Task<IEnumerable<Notification>> GetByCustomerAsync(
            int customerId);

        Task<IEnumerable<Notification>> GetUnreadAsync(
            int customerId);

        Task<IEnumerable<Notification>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<Notification>> SearchAsync(
            string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<Notification>> GetSortedAsync(
            string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<Notification>> GetPagedAsync(
            int page,
            int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<NotificationStatistics> GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task AddAsync(Notification notification);

        Task UpdateAsync(Notification notification);

        Task DeleteAsync(int notificationId);

        Task SaveChangesAsync();
    }
}