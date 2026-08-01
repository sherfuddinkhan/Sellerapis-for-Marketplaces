using Marketplacesellerportal.Models;
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

        public async Task<IEnumerable<Review>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Review?> GetByIdAsync(int reviewId) =>
            await _repository.GetByIdAsync(reviewId);

        public async Task<IEnumerable<Review>> GetByProductAsync(int productId) =>
            await _repository.GetByProductAsync(productId);

        public async Task<IEnumerable<Review>> GetByCustomerAsync(int customerId) =>
            await _repository.GetByCustomerAsync(customerId);

        public async Task<Review> CreateAsync(Review review)
        {
            review.CreatedDate = DateTime.Now;

            await _repository.AddAsync(review);
            await _repository.SaveChangesAsync();

            return review;
        }

        public async Task<bool> UpdateAsync(int reviewId, Review review)
        {
            var existing = await _repository.GetByIdAsync(reviewId);

            if (existing == null)
                return false;

            existing.CustomerId = review.CustomerId;
            existing.ProductId = review.ProductId;
            existing.Rating = review.Rating;
            existing.ReviewText = review.ReviewText;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int reviewId)
        {
            var existing = await _repository.GetByIdAsync(reviewId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(reviewId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
