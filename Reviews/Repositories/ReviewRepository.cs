using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.DTOs;
using Marketplacesellerportal.Reviews.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Review>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.Reviews
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<Review?> GetByIdAsync(int reviewId)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId);
        }
        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetBySellerIdAsync(int sellerId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByCustomerIdAsync(int customerId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY RATING
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByRatingAsync(int rating)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.Rating == rating)
                .ToListAsync();
        }


        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetByStatusAsync(string status)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.Status == status)
                .ToListAsync();
        }


        // =========================================================
        // STATISTICS
        // GET /api/reviews/stats
        // =========================================================

        public async Task<ReviewStatistics>
            GetStatisticsAsync()
        {
            var query = _context.Reviews
                .AsNoTracking();

            var totalRecords =
                await query.CountAsync();

            var fiveStarCount =
                await query.CountAsync(x =>
                    x.Rating == 5);

            var fourStarCount =
                await query.CountAsync(x =>
                    x.Rating == 4);

            var threeStarCount =
                await query.CountAsync(x =>
                    x.Rating == 3);

            var twoStarCount =
                await query.CountAsync(x =>
                    x.Rating == 2);

            var oneStarCount =
                await query.CountAsync(x =>
                    x.Rating == 1);

            var approvedCount =
                await query.CountAsync(x =>
                    x.Status == "approved");

            var pendingCount =
                await query.CountAsync(x =>
                    x.Status == "pending");

            var rejectedCount =
                await query.CountAsync(x =>
                    x.Status == "rejected");

            var distinctProducts =
                await query
                    .Select(x => x.ProductId)
                    .Distinct()
                    .CountAsync();

            var distinctCustomers =
                await query
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .CountAsync();

            var distinctSellers =
                await query
                    .Select(x => x.SellerId)
                    .Distinct()
                    .CountAsync();

            decimal averageRating = 0;

            if (totalRecords > 0)
            {
                averageRating =
                    await query
                        .AverageAsync(x =>
                            (decimal)x.Rating);
            }

            return new ReviewStatistics
            {
                TotalRecords =
                    totalRecords,

                FiveStarCount =
                    fiveStarCount,

                FourStarCount =
                    fourStarCount,

                ThreeStarCount =
                    threeStarCount,

                TwoStarCount =
                    twoStarCount,

                OneStarCount =
                    oneStarCount,

                ApprovedCount =
                    approvedCount,

                PendingCount =
                    pendingCount,

                RejectedCount =
                    rejectedCount,

                AverageRating =
                    averageRating,

                DistinctProducts =
                    distinctProducts,

                DistinctCustomers =
                    distinctCustomers,

                DistinctSellers =
                    distinctSellers
            };
        }
        public async Task<IEnumerable<Review>> SearchAsync(
    string? search,
    int? rating,
    string? status)
        {
            var query = _context.Reviews
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
      x.ReviewText != null &&
      x.ReviewText.Contains(search));
            }

            if (rating.HasValue)
            {
                query = query.Where(x =>
                    x.Rating == rating.Value);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(x =>
                    x.Status == status);
            }

            return await query.ToListAsync();
        }
        // =========================================================
        // PAGINATION
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

            var query = _context.Reviews
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x => x.ReviewId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                Items: items,
                TotalCount: totalCount
            );
        }


        // =========================================================
        // SORTING
        // GET /api/reviews?sort=rating_asc
        // GET /api/reviews?sort=rating_desc
        // GET /api/reviews?sort=date_asc
        // GET /api/reviews?sort=date_desc
        // =========================================================

        public async Task<IEnumerable<Review>>
            GetSortedAsync(string? sort)
        {
            var query = _context.Reviews
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "rating_asc":

                    query = query
                        .OrderBy(x => x.Rating);

                    break;

                case "rating_desc":

                    query = query
                        .OrderByDescending(x => x.Rating);

                    break;

                case "date_asc":

                    query = query
                        .OrderBy(x => x.CreatedDate);

                    break;

                case "date_desc":

                    query = query
                        .OrderByDescending(x => x.CreatedDate);

                    break;

                case "id_asc":

                    query = query
                        .OrderBy(x => x.ReviewId);

                    break;

                case "id_desc":
                default:

                    query = query
                        .OrderByDescending(x => x.ReviewId);

                    break;
            }

            return await query.ToListAsync();
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
