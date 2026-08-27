using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.DTOs;

namespace Marketplacesellerportal.Notifications.Interfaces
{
    public interface INotificationService
    {
        // =====================================================
        // GET ALL
        // =====================================================

        Task<IEnumerable<Notification>> GetAllAsync();

        // =====================================================
        // GET BY ID
        // =====================================================

        Task<Notification?> GetByIdAsync(
            int notificationId);

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        Task<IEnumerable<Notification>> GetByCustomerAsync(
            int customerId);

        // =====================================================
        // GET UNREAD
        // =====================================================

        Task<IEnumerable<Notification>> GetUnreadAsync(
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
        // CREATE
        // =====================================================

        Task<Notification> CreateAsync(
            Notification notification);

        // =====================================================
        // MARK AS READ
        // =====================================================

        Task<bool> MarkAsReadAsync(
            int notificationId);

        // =====================================================
        // UPDATE
        // =====================================================

        Task<bool> UpdateAsync(
            int notificationId,
            Notification notification);

        // =====================================================
        // DELETE
        // =====================================================

        Task<bool> DeleteAsync(
            int notificationId);
    }
}