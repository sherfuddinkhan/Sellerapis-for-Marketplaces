using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;

namespace Marketplacesellerportal.PurchaseOrderItems.Repositories
{
    public class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetAllAsync()
        {
            return await _context.PurchaseOrderItems
                .ToListAsync();
        }

        public async Task<PurchaseOrderItem?> GetByIdAsync(int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseOrderItems
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        public async Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        public async Task AddAsync(PurchaseOrderItem item)
        {
            await _context.PurchaseOrderItems.AddAsync(item);
        }

        public Task UpdateAsync(PurchaseOrderItem item)
        {
            _context.PurchaseOrderItems.Update(item);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int purchaseOrderItemId)
        {
            var item = await GetByIdAsync(purchaseOrderItemId);

            if (item != null)
            {
                _context.PurchaseOrderItems.Remove(item);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

