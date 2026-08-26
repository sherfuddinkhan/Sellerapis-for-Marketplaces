using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.DTOs;

namespace Marketplacesellerportal.Reviews.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(
            int reviewId);

        Task<IEnumerable<Review>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<Review>> GetByCustomerIdAsync(
            int customerId);

        Task<IEnumerable<Review>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<Review>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<Review>> GetByRatingAsync(
            int rating);

        Task<IEnumerable<Review>> GetByStatusAsync(
            string status);

        Task<IEnumerable<Review>> SearchAsync(
            string? search,
            int? rating,
            string? status);

        Task<ReviewStatistics> GetStatisticsAsync();

        Task<(
            IEnumerable<Review> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<Review>> GetSortedAsync(
            string? sort);

        Task AddAsync(
            Review review);

        Task UpdateAsync(
            Review review);

        Task DeleteAsync(
            int reviewId);

        Task SaveChangesAsync();
    }
}