using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.WishlistItems.Interfaces;

namespace Marketplacesellerportal.WishlistItems.Repositories
{
    public class WishlistItemRepository : IWishlistItemRepository
    {
        private readonly ApplicationDbContext _context;

        public WishlistItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WishlistItem>> GetAllAsync()
        {
            return await _context.WishlistItems.ToListAsync();
        }

        public async Task<WishlistItem?> GetByIdAsync(int wishlistItemId)
        {
            return await _context.WishlistItems
                .FirstOrDefaultAsync(x => x.WishlistItemId == wishlistItemId);
        }

        public async Task<IEnumerable<WishlistItem>> GetByWishlistAsync(int wishlistId)
        {
            return await _context.WishlistItems
                .Where(x => x.WishlistId == wishlistId)
                .ToListAsync();
        }

        public async Task<IEnumerable<WishlistItem>> GetByProductAsync(int productId)
        {
            return await _context.WishlistItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task AddAsync(WishlistItem wishlistItem)
        {
            await _context.WishlistItems.AddAsync(wishlistItem);
        }

        public Task UpdateAsync(WishlistItem wishlistItem)
        {
            _context.WishlistItems.Update(wishlistItem);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int wishlistItemId)
        {
            var entity = await GetByIdAsync(wishlistItemId);

            if (entity != null)
                _context.WishlistItems.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
