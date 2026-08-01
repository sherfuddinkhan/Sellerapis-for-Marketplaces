using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.WishlistItems.Interfaces
{
    public interface IWishlistItemService
    {
        Task<IEnumerable<WishlistItem>> GetAllAsync();

        Task<WishlistItem?> GetByIdAsync(int wishlistItemId);

        Task<IEnumerable<WishlistItem>> GetByWishlistAsync(int wishlistId);

        Task<IEnumerable<WishlistItem>> GetByProductAsync(int productId);

        Task<WishlistItem> CreateAsync(WishlistItem wishlistItem);

        Task<bool> UpdateAsync(int wishlistItemId, WishlistItem wishlistItem);

        Task<bool> DeleteAsync(int wishlistItemId);
    }
}
