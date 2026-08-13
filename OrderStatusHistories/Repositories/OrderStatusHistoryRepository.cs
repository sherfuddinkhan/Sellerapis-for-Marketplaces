using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;
using System.Xml.Linq;

namespace Marketplacesellerportal.OrderStatusHistories.Repositories
{
    public class OrderStatusHistoryRepository : IOrderStatusHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderStatusHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetAllAsync()
        {
            return await _context.OrderStatusHistories.ToListAsync();
        }

        public async Task<OrderStatusHistory?> GetByIdAsync(int historyId)
        {
            return await _context.OrderStatusHistories
                .FirstOrDefaultAsync(x => x.OrderStatusHistoryId == historyId);
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderStatusHistories
                .Where(x => x.OrderId == orderId)
                .OrderByDescending(x => x.ChangedOn)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status)
        {
            return await _context.OrderStatusHistories
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task AddAsync(OrderStatusHistory history)
        {
            await _context.OrderStatusHistories.AddAsync(history);
        }

        public Task UpdateAsync(OrderStatusHistory history)
        {
            _context.OrderStatusHistories.Update(history);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int historyId)
        {
            var entity = await GetByIdAsync(historyId);

            if (entity != null)
                _context.OrderStatusHistories.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
