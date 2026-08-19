using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.SalesOrderItems.Repositories
{
    public class SalesOrderItemRepository : ISalesOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrderItem>> GetAllAsync()
        {
            return await _context.SalesOrderItems
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(
    int salesOrderId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrdersAsync(
    List<int> salesOrderIds)
        {
            return await _context.SalesOrderItems
                .Where(x => salesOrderIds.Contains(x.SalesOrderId))
                .ToListAsync();
        }
        public async Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId)
        {
            return await _context.SalesOrderItems
                .FirstOrDefaultAsync(x =>
                    x.SalesOrderItemId == salesOrderItemId);
        }
        public async Task<IEnumerable<SalesOrderItem>> GetByProductAsync(
    int productId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderIdAsync(
            int salesOrderId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesOrderItem>> GetByProductIdAsync(
            int productId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task AddAsync(SalesOrderItem salesOrderItem)
        {
            await _context.SalesOrderItems.AddAsync(salesOrderItem);
        }

        public Task UpdateAsync(SalesOrderItem salesOrderItem)
        {
            _context.SalesOrderItems.Update(salesOrderItem);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int salesOrderItemId)
        {
            var entity = await GetByIdAsync(salesOrderItemId);

            if (entity != null)
            {
                _context.SalesOrderItems.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}