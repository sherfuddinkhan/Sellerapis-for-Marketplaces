
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.PurchaseOrderItems.Repositories
{
    public class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // =====================================================
        public async Task<IEnumerable<PurchaseOrderItem>> GetAllAsync()
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================
        public async Task<PurchaseOrderItem?> GetByIdAsync(
            int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        public async Task<IEnumerable<PurchaseOrderItem>>
    GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }
        // =====================================================
        // GET BY PURCHASE ORDER + ITEM
        // =====================================================
        public async Task<PurchaseOrderItem?>
            GetByPurchaseOrderAndItemIdAsync(
                int purchaseOrderId,
                int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER + PURCHASE ORDERS
        // =====================================================
        public async Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrdersAsync(
                int sellerId,
                int customerId,
                List<int> purchaseOrderIds)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId &&
                    purchaseOrderIds.Contains(x.PurchaseOrderId))
                .ToListAsync();
        }

        // =====================================================
        // ADD
        // =====================================================
        public async Task AddAsync(PurchaseOrderItem item)
        {
            await _context.PurchaseOrderItems.AddAsync(item);
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public async Task UpdateAsync(PurchaseOrderItem item)
        {
            _context.PurchaseOrderItems.Update(item);

            await Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================
        public async Task DeleteAsync(int purchaseOrderItemId)
        {
            var item = await _context.PurchaseOrderItems
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderItemId == purchaseOrderItemId);

            if (item != null)
            {
                _context.PurchaseOrderItems.Remove(item);
            }
        }

        // =====================================================
        // SAVE
        // =====================================================
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}