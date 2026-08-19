using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.GoodsReceiptItems.Interfaces;

namespace Marketplacesellerportal.GoodsReceiptItems.Repositories
{
    public class GoodsReceiptItemRepository : IGoodsReceiptItemRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GoodsReceiptItem>> GetAllAsync()
        {
            return await _context.GoodsReceiptItems.ToListAsync();
        }
        public async Task<IEnumerable<GoodsReceiptItem>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.GoodsReceiptItems
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<GoodsReceiptItem?> GetByIdAsync(int goodsReceiptItemId)
        {
            return await _context.GoodsReceiptItems
                .FirstOrDefaultAsync(x => x.GoodsReceiptItemId == goodsReceiptItemId);
        }

        public async Task<IEnumerable<GoodsReceiptItem>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId)
        {
            return await _context.GoodsReceiptItems
                .Where(x => x.GoodsReceiptNoteId == goodsReceiptNoteId)
                .ToListAsync();
        }

        public async Task<GoodsReceiptItem?> GetByGoodsReceiptNoteAndItemAsync(
            int goodsReceiptNoteId,
            int goodsReceiptItemId)
        {
            return await _context.GoodsReceiptItems
                .FirstOrDefaultAsync(x =>
                    x.GoodsReceiptNoteId == goodsReceiptNoteId &&
                    x.GoodsReceiptItemId == goodsReceiptItemId);
        }

        public async Task AddAsync(GoodsReceiptItem goodsReceiptItem)
        {
            await _context.GoodsReceiptItems.AddAsync(goodsReceiptItem);
        }

        public Task UpdateAsync(GoodsReceiptItem goodsReceiptItem)
        {
            _context.GoodsReceiptItems.Update(goodsReceiptItem);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int goodsReceiptItemId)
        {
            var entity = await GetByIdAsync(goodsReceiptItemId);

            if (entity != null)
                _context.GoodsReceiptItems.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
