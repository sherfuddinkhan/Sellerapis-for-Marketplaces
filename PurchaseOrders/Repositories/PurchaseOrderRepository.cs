using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.Interfaces;

namespace Marketplacesellerportal.PurchaseOrders.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PurchaseOrder>>
    GetBySellerCustomerAsync(int sellerId, int customerId)
        {
            return await _context.PurchaseOrders
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x => x.PurchaseOrderId == purchaseOrderId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.PurchaseOrders
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.PurchaseOrders
                .Where(x => x.SupplierId == supplierId)
                .ToListAsync();
        }
        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
        }

        public Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Update(purchaseOrder);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int purchaseOrderId)
        {
            var po = await GetByIdAsync(purchaseOrderId);

            if (po != null)
                _context.PurchaseOrders.Remove(po);
        }
        public async Task<PurchaseOrder?> GetPurchaseOrderAsync(
          int sellerId,
          int customerId,
          int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.SellerId == customerId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }
        public async Task<PurchaseOrder?> GetBySellerAndPurchaseOrderIdAsync(
    int sellerId,
    int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }
        public async Task<PurchaseOrder?> GetBySellerSupplierAndPurchaseOrderIdAsync(
    int sellerId,
    int supplierId,
    int purchaseOrderId)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.SupplierId == supplierId &&
                    x.PurchaseOrderId == purchaseOrderId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
