using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.Interfaces;

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
    }
}
