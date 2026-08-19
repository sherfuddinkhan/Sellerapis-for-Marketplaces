using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Wishlists.Interfaces;

namespace Marketplacesellerportal.Wishlists.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly ApplicationDbContext _context;

        public WishlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> GetAllAsync()
        {
            return await _context.Wishlists.ToListAsync();
        }

        public async Task<Wishlist?> GetByIdAsync(int wishlistId)
        {
            return await _context.Wishlists
                .FirstOrDefaultAsync(x => x.WishlistId == wishlistId);
        }

        public async Task<IEnumerable<Wishlist>> GetByCustomerAsync(int customerId)
        {
            return await _context.Wishlists
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Wishlist>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.Wishlists
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddAsync(Wishlist wishlist)
        {
            await _context.Wishlists.AddAsync(wishlist);
        }

        public Task UpdateAsync(Wishlist wishlist)
        {
            _context.Wishlists.Update(wishlist);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int wishlistId)
        {
            var entity = await GetByIdAsync(wishlistId);

            if (entity != null)
                _context.Wishlists.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
