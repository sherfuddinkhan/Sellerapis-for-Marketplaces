using Marketplacesellerportal.Models;
using Marketplacesellerportal.Wishlists.Interfaces;

namespace Marketplacesellerportal.Wishlists.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _repository;

        public WishlistService(IWishlistRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Wishlist>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Wishlist?> GetByIdAsync(int wishlistId)
        {
            return await _repository.GetByIdAsync(wishlistId);
        }

        public async Task<IEnumerable<Wishlist>> GetByCustomerAsync(int customerId)
        {
            return await _repository.GetByCustomerAsync(customerId);
        }

        public async Task<Wishlist> CreateAsync(Wishlist wishlist)
        {
            wishlist.CreatedDate = DateTime.Now;

            await _repository.AddAsync(wishlist);
            await _repository.SaveChangesAsync();

            return wishlist;
        }

        public async Task<bool> UpdateAsync(int wishlistId, Wishlist wishlist)
        {
            var existing = await _repository.GetByIdAsync(wishlistId);

            if (existing == null)
                return false;

            existing.CustomerId = wishlist.CustomerId;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int wishlistId)
        {
            var existing = await _repository.GetByIdAsync(wishlistId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(wishlistId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
