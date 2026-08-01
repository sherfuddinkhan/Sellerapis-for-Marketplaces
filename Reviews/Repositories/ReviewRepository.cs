using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.Interfaces;

namespace Marketplacesellerportal.Reviews.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int reviewId)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId);
        }

        public async Task<IEnumerable<Review>> GetByProductAsync(int productId)
        {
            return await _context.Reviews
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByCustomerAsync(int customerId)
        {
            return await _context.Reviews
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int reviewId)
        {
            var entity = await GetByIdAsync(reviewId);

            if (entity != null)
                _context.Reviews.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
