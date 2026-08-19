using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Repositories
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseReturnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseReturn>> GetAllAsync()
        {
            return await _context.PurchaseReturns.ToListAsync();
        }
        public async Task<IEnumerable<PurchaseReturn>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.PurchaseReturns
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<PurchaseReturn?> GetByIdAsync(int purchaseReturnId)
        {
            return await _context.PurchaseReturns
                .FirstOrDefaultAsync(x => x.PurchaseReturnId == purchaseReturnId);
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseReturns
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReturn>> GetBySupplierIdAsync(int supplierId)
        {
            return await _context.PurchaseReturns
                .Where(x => x.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId)
        {
            return await _context.PurchaseReturns
                .Where(x => x.GoodsReceiptNoteId == goodsReceiptNoteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByStatusAsync(string status)
        {
            return await _context.PurchaseReturns
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<PurchaseReturn?> GetPurchaseReturnAsync(
            int purchaseOrderId,
            int supplierId,
            int purchaseReturnId)
        {
            return await _context.PurchaseReturns.FirstOrDefaultAsync(x =>
                x.PurchaseOrderId == purchaseOrderId &&
                x.SupplierId == supplierId &&
                x.PurchaseReturnId == purchaseReturnId);
        }

        public async Task AddAsync(PurchaseReturn purchaseReturn)
        {
            await _context.PurchaseReturns.AddAsync(purchaseReturn);
        }

        public Task UpdateAsync(PurchaseReturn purchaseReturn)
        {
            _context.PurchaseReturns.Update(purchaseReturn);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int purchaseReturnId)
        {
            var entity = await GetByIdAsync(purchaseReturnId);

            if (entity != null)
                _context.PurchaseReturns.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
