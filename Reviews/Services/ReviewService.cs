using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.DTOs;
using Marketplacesellerportal.Reviews.Interfaces;

namespace Marketplacesellerportal.Reviews.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Review?>
            GetByIdAsync(
                int reviewId)
        {
            return await _repository.GetByIdAsync(
                reviewId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }
        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetBySellerCustomerAsync(
                    sellerId,
                    customerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository.GetByProductIdAsync(
                productId);
        }

        // =========================================================
        // GET BY RATING
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByRatingAsync(
                int rating)
        {
            return await _repository.GetByRatingAsync(
                rating);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByStatusAsync(
                string status)
        {
            return await _repository.GetByStatusAsync(
                status);
        }

        // =========================================================
        // SEARCH
        //
        // GET /api/reviews?search=excellent
        // GET /api/reviews?rating=5
        // GET /api/reviews?status=approved
        // GET /api/reviews?search=excellent&rating=5&status=approved
        // =========================================================

        public async Task<IEnumerable<Review>>
            SearchAsync(
                string? search,
                int? rating,
                string? status)
        {
            return await _repository.SearchAsync(
                search,
                rating,
                status);
        }

        // =========================================================
        // STATISTICS
        //
        // GET /api/reviews/stats
        // =========================================================

        public async Task<ReviewStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        //
        // GET /api/reviews?page=1&limit=10
        // =========================================================

        public async Task<(
            IEnumerable<Review> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        //
        // date_asc
        // date_desc
        // rating_asc
        // rating_desc
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<Review>
            CreateAsync(
                Review review)
        {
            review.CreatedDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(review.Status))
            {
                review.Status = "pending";
            }

            await _repository.AddAsync(
                review);

            await _repository.SaveChangesAsync();

            return review;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int reviewId,
                Review review)
        {
            var existing =
                await _repository.GetByIdAsync(
                    reviewId);

            if (existing == null)
                return false;

            existing.CustomerId =
                review.CustomerId;

            existing.SellerId =
                review.SellerId;

            existing.ProductId =
                review.ProductId;

            existing.Rating =
                review.Rating;

            existing.ReviewText =
                review.ReviewText;

            existing.Status =
                review.Status;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int reviewId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    reviewId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                reviewId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}