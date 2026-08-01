using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.WishlistItems.Interfaces
{
    public interface IWishlistItemRepository
    {
        Task<IEnumerable<WishlistItem>> GetAllAsync();

        Task<WishlistItem?> GetByIdAsync(int wishlistItemId);

        Task<IEnumerable<WishlistItem>> GetByWishlistAsync(int wishlistId);

        Task<IEnumerable<WishlistItem>> GetByProductAsync(int productId);

        Task AddAsync(WishlistItem wishlistItem);

        Task UpdateAsync(WishlistItem wishlistItem);

        Task DeleteAsync(int wishlistItemId);

        Task SaveChangesAsync();
    }
}
