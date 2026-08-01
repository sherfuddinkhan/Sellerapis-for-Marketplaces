using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Wishlists.Interfaces
{
    public interface IWishlistRepository
    {
        Task<IEnumerable<Wishlist>> GetAllAsync();

        Task<Wishlist?> GetByIdAsync(int wishlistId);

        Task<IEnumerable<Wishlist>> GetByCustomerAsync(int customerId);

        Task AddAsync(Wishlist wishlist);

        Task UpdateAsync(Wishlist wishlist);

        Task DeleteAsync(int wishlistId);

        Task SaveChangesAsync();
    }
}
