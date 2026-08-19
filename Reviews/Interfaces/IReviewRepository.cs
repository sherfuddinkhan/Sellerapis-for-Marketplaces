using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Reviews.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(int reviewId);

        Task<IEnumerable<Review>> GetByProductAsync(int productId);

        Task<IEnumerable<Review>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<Review>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task AddAsync(Review review);

        Task UpdateAsync(Review review);

        Task DeleteAsync(int reviewId);

        Task SaveChangesAsync();
    }
}
