using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.Interfaces;

namespace Marketplacesellerportal.SalesOrders.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllAsync()
        {
            return await _context.SalesOrders.ToListAsync();
        }

        public async Task<SalesOrder?> GetByIdAsync(int salesOrderId)
        {
            return await _context.SalesOrders
                .FirstOrDefaultAsync(x => x.SalesOrderId == salesOrderId);
        }

        public async Task<IEnumerable<SalesOrder>> GetBySellerAsync(int sellerId)
        {
            return await _context.SalesOrders
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId)
        {
            return await _context.SalesOrders
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status)
        {
            return await _context.SalesOrders
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<SalesOrder?> GetBySalesOrderNumberAsync(string salesOrderNumber)
        {
            return await _context.SalesOrders
                .FirstOrDefaultAsync(x => x.SalesOrderNumber == salesOrderNumber);
        }

        public async Task AddAsync(SalesOrder salesOrder)
        {
            await _context.SalesOrders.AddAsync(salesOrder);
        }

        public Task UpdateAsync(SalesOrder salesOrder)
        {
            _context.SalesOrders.Update(salesOrder);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int salesOrderId)
        {
            var entity = await GetByIdAsync(salesOrderId);

            if (entity != null)
                _context.SalesOrders.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
