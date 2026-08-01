using Marketplacesellerportal.Models;
using Marketplacesellerportal.WishlistItems.Interfaces;

namespace Marketplacesellerportal.WishlistItems.Services
{
    public class WishlistItemService : IWishlistItemService
    {
        private readonly IWishlistItemRepository _repository;

        public WishlistItemService(IWishlistItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WishlistItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WishlistItem?> GetByIdAsync(int wishlistItemId)
        {
            return await _repository.GetByIdAsync(wishlistItemId);
        }

        public async Task<IEnumerable<WishlistItem>> GetByWishlistAsync(int wishlistId)
        {
            return await _repository.GetByWishlistAsync(wishlistId);
        }

        public async Task<IEnumerable<WishlistItem>> GetByProductAsync(int productId)
        {
            return await _repository.GetByProductAsync(productId);
        }

        public async Task<WishlistItem> CreateAsync(WishlistItem wishlistItem)
        {
            wishlistItem.CreatedDate = DateTime.Now;

            await _repository.AddAsync(wishlistItem);
            await _repository.SaveChangesAsync();

            return wishlistItem;
        }

        public async Task<bool> UpdateAsync(int wishlistItemId, WishlistItem wishlistItem)
        {
            var existing = await _repository.GetByIdAsync(wishlistItemId);

            if (existing == null)
                return false;

            existing.WishlistId = wishlistItem.WishlistId;
            existing.ProductId = wishlistItem.ProductId;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int wishlistItemId)
        {
            var existing = await _repository.GetByIdAsync(wishlistItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(wishlistItemId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
