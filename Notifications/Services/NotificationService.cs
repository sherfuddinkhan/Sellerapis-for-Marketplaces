using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.DTOs;
using Marketplacesellerportal.Notifications.Interfaces;

namespace Marketplacesellerportal.Notifications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(
            INotificationRepository repository)
        {
            _repository = repository;
        }

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<Notification?> GetByIdAsync(
            int notificationId)
        {
            return await _repository.GetByIdAsync(notificationId);
        }

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        public async Task<IEnumerable<Notification>> GetByCustomerAsync(
            int customerId)
        {
            return await _repository.GetByCustomerAsync(customerId);
        }

        // =====================================================
        // GET UNREAD
        // =====================================================

        public async Task<IEnumerable<Notification>> GetUnreadAsync(
            int customerId)
        {
            return await _repository.GetUnreadAsync(customerId);
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        public async Task<IEnumerable<Notification>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }

        // =====================================================
        // SEARCH
        // =====================================================

        public async Task<IEnumerable<Notification>> SearchAsync(
            string search)
        {
            return await _repository.SearchAsync(search);
        }

        // =====================================================
        // SORT
        // =====================================================

        public async Task<IEnumerable<Notification>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        // =====================================================
        // PAGINATION
        // =====================================================

        public async Task<PagedResult<Notification>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =====================================================
        // STATISTICS
        // =====================================================

        public async Task<NotificationStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task<Notification> CreateAsync(
            Notification notification)
        {
            notification.CreatedDate = DateTime.Now;
            notification.IsRead = false;

            await _repository.AddAsync(notification);
            await _repository.SaveChangesAsync();

            return notification;
        }

        // =====================================================
        // MARK AS READ
        // =====================================================

        public async Task<bool> MarkAsReadAsync(
            int notificationId)
        {
            var notification =
                await _repository.GetByIdAsync(notificationId);

            if (notification == null)
                return false;

            notification.IsRead = true;

            await _repository.UpdateAsync(notification);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public async Task<bool> UpdateAsync(
            int notificationId,
            Notification notification)
        {
            var existing =
                await _repository.GetByIdAsync(notificationId);

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

        // =====================================================
        // DELETE
        // =====================================================

        public async Task<bool> DeleteAsync(
            int notificationId)
        {
            var existing =
                await _repository.GetByIdAsync(notificationId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(notificationId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

