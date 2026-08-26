using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.DTOs;

namespace Marketplacesellerportal.Reviews.Interfaces
{
    public interface IReviewService
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(
            int reviewId);

        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<Review>> GetBySellerIdAsync(
            int sellerId);

        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<Review>> GetByCustomerIdAsync(
            int customerId);

        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<Review>> GetByProductIdAsync(
            int productId);

        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<Review>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =========================================================
        // RATING
        // =========================================================

        Task<IEnumerable<Review>> GetByRatingAsync(
            int rating);

        // =========================================================
        // STATUS
        // =========================================================

        Task<IEnumerable<Review>> GetByStatusAsync(
            string status);

        // =========================================================
        // SEARCH + RATING + STATUS
        //
        // /api/reviews?search=excellent
        // /api/reviews?rating=5&status=approved
        // =========================================================

        Task<IEnumerable<Review>> SearchAsync(
            string? search,
            int? rating,
            string? status);

        // =========================================================
        // STATISTICS
        // =========================================================

        Task<ReviewStatistics> GetStatisticsAsync();

        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<Review> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<Review>> GetSortedAsync(
            string? sort);

        // =========================================================
        // CRUD
        // =========================================================

        Task<Review> CreateAsync(
            Review review);

        Task<bool> UpdateAsync(
            int reviewId,
            Review review);

        Task<bool> DeleteAsync(
            int reviewId);
    }
}