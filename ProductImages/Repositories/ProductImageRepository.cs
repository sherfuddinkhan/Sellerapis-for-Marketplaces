using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductImages.DTOs;
using Marketplacesellerportal.ProductImages.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductImageModel = Marketplacesellerportal.Models.ProductImage;

namespace Marketplacesellerportal.ProductImages.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetAllAsync()
        {
            return await _context.ProductImages
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductImageModel?> GetByIdAsync(
            int productImageId)
        {
            return await _context.ProductImages
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.ProductImageId == productImageId);
        }

        // =========================================================
        // GET BY PRODUCT ID
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetByProductIdAsync(
            int productId)
        {
            return await _context.ProductImages
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PRODUCT IDS
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetByProductIdsAsync(
            IEnumerable<int> productIds)
        {
            return await _context.ProductImages
                .AsNoTracking()
                .Where(x => productIds.Contains(x.ProductId))
                .ToListAsync();
        }

        // =========================================================
        // GET PRIMARY IMAGES
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetPrimaryImagesAsync()
        {
            return await _context.ProductImages
        .AsNoTracking()
        .Where(x => x.IsPrimary==true)
        .ToListAsync();
        }

        // =========================================================
        // GET PRIMARY IMAGE BY PRODUCT
        // =========================================================

        public async Task<ProductImageModel?> GetPrimaryImageAsync(
            int productId)
        {
            return await _context.ProductImages
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x =>
                        x.ProductId == productId &&
                        x.IsPrimary==true);
        }

        // =========================================================
        // ADD
        // =========================================================

        public async Task AddAsync(ProductImageModel productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task UpdateAsync(ProductImageModel productImage)
        {
            _context.ProductImages.Update(productImage);
            await Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(int productImageId)
        {
            var image = await _context.ProductImages
                .FirstOrDefaultAsync(
                    x => x.ProductImageId == productImageId);

            if (image != null)
            {
                _context.ProductImages.Remove(image);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // =========================================================
        // SEARCH
        // GET /api/product-images?search=banner
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> SearchAsync(
            string? search)
        {
            var query = _context.ProductImages
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.ImageUrl.Contains(search));
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // GET /api/product-images/stats
        // =========================================================

        public async Task<ProductImageStatistics> GetStatisticsAsync()
        {
            var total = await _context.ProductImages
                .CountAsync();

            var active = await _context.ProductImages
                .CountAsync(x => x.IsActive);

            var inactive = await _context.ProductImages
                .CountAsync(x => !x.IsActive);

            var primary = await _context.ProductImages
                .CountAsync(x => x.IsPrimary == true);

            var totalSize = await _context.ProductImages
                .Select(x => (long?)x.ImageSize)
                .SumAsync() ?? 0;

            return new ProductImageStatistics
            {
                TotalImages = total,
                ActiveImages = active,
                InactiveImages = inactive,
                PrimaryImages = primary,
                TotalImageSize = totalSize
            };
        }

        // =========================================================
        // PAGINATION
        // GET /api/product-images?page=1&limit=24
        // =========================================================

        public async Task<(
            IEnumerable<ProductImageModel> Items,
            int TotalCount)> GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 24;

            var query = _context.ProductImages
                .AsNoTracking()
                .OrderByDescending(x => x.ProductImageId);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalCount);
        }

        // =========================================================
        // SORTING
        // GET /api/product-images?sort=size_desc
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetSortedAsync(
            string? sort)
        {
            var query = _context.ProductImages
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "size_desc":

                    query = query
                        .OrderByDescending(x => x.ImageSize);

                    break;

                case "size_asc":

                    query = query
                        .OrderBy(x => x.ImageSize);

                    break;

                case "newest":

                    query = query
                        .OrderByDescending(x => x.ProductImageId);

                    break;

                case "oldest":

                    query = query
                        .OrderBy(x => x.ProductImageId);

                    break;

                default:

                    query = query
                        .OrderByDescending(x => x.ProductImageId);

                    break;
            }

            return await query.ToListAsync();
        }
    }
}