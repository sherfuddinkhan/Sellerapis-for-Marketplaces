using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Reviews.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(int reviewId);

        Task<IEnumerable<Review>> GetByProductAsync(int productId);

        Task<IEnumerable<Review>> GetByCustomerAsync(int customerId);

        Task<Review> CreateAsync(Review review);

        Task<bool> UpdateAsync(int reviewId, Review review);

        Task<bool> DeleteAsync(int reviewId);
    }
}
