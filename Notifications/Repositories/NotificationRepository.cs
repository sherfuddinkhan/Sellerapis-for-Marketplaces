using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.Interfaces;
using Marketplacesellerportal.Notifications.DTOs;
namespace Marketplacesellerportal.Notifications.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(int notificationId)
        {
            return await _context.Notifications
                .FirstOrDefaultAsync(x => x.NotificationId == notificationId);
        }
        public async Task<IEnumerable<Notification>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.Notifications
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Notification>> GetByCustomerAsync(int customerId)
        {
            return await _context.Notifications
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadAsync(int customerId)
        {
            return await _context.Notifications
                .Where(x => x.CustomerId == customerId && x.IsRead == false)
                .ToListAsync();
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public Task UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int notificationId)
        {
            var entity = await GetByIdAsync(notificationId);

            if (entity != null)
                _context.Notifications.Remove(entity);
        }
      


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        // =====================================================
        // SEARCH
        // =====================================================
        public async Task<IEnumerable<Notification>> SearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.Notifications
                    .AsNoTracking()
                    .ToListAsync();
            }

            search = search.Trim();

            return await _context.Notifications
                .AsNoTracking()
                .Where(x =>
                    x.Title.Contains(search) ||
                    x.Message.Contains(search))
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetSortedAsync(
            string? sort)
        {
            var query = _context.Notifications
                .AsNoTracking()
                .AsQueryable();

            query = sort?.ToLower() switch
            {
                "date_asc" =>
                    query.OrderBy(x => x.CreatedDate),

                "date_desc" =>
                    query.OrderByDescending(x => x.CreatedDate),

                "title_asc" =>
                    query.OrderBy(x => x.Title),

                "title_desc" =>
                    query.OrderByDescending(x => x.Title),

                _ =>
                    query.OrderByDescending(x => x.NotificationId)
            };

            return await query.ToListAsync();
        }

        public async Task<PagedResult<Notification>> GetPagedAsync(
            int page,
            int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.Notifications
                .AsNoTracking()
                .OrderByDescending(x => x.NotificationId);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<Notification>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }

        public async Task<NotificationStatistics>
            GetStatisticsAsync()
        {
            var notifications =
                _context.Notifications.AsNoTracking();

            return new NotificationStatistics
            {
                TotalNotifications =
                    await notifications.CountAsync(),

                UnreadNotifications =
                    await notifications.CountAsync(x => !x.IsRead),

                ReadNotifications =
                    await notifications.CountAsync(x => x.IsRead)
            };
        }
    }
}
