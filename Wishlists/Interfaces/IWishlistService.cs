using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Wishlists.Interfaces
{
    public interface IWishlistService
    {
        Task<IEnumerable<Wishlist>> GetAllAsync();

        Task<Wishlist?> GetByIdAsync(int wishlistId);

        Task<IEnumerable<Wishlist>> GetByCustomerAsync(int customerId);

        Task<Wishlist> CreateAsync(Wishlist wishlist);

        Task<bool> UpdateAsync(int wishlistId, Wishlist wishlist);

        Task<bool> DeleteAsync(int wishlistId);
    }
}
