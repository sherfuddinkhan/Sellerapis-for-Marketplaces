using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductImages.DTOs;

using ProductImageModel = Marketplacesellerportal.Models.ProductImage;

namespace Marketplacesellerportal.ProductImages.Interfaces
{
    public interface IProductImageRepository
    {
        // =========================================================
        // BASIC CRUD
        // =========================================================

        Task<IEnumerable<ProductImageModel>> GetAllAsync();

        Task<ProductImageModel?> GetByIdAsync(
            int productImageId);

        Task<IEnumerable<ProductImageModel>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductImageModel>> GetByProductIdsAsync(
            IEnumerable<int> productIds);

        Task<IEnumerable<ProductImageModel>> GetPrimaryImagesAsync();

        Task<ProductImageModel?> GetPrimaryImageAsync(
            int productId);

        Task AddAsync(
            ProductImageModel productImage);

        Task UpdateAsync(
            ProductImageModel productImage);

        Task DeleteAsync(
            int productImageId);

        Task SaveChangesAsync();


        // =========================================================
        // SEARCH
        // GET /api/product-images?search=banner
        // =========================================================

        Task<IEnumerable<ProductImageModel>> SearchAsync(
            string? search);


        // =========================================================
        // STATISTICS
        // GET /api/product-images/stats
        // =========================================================

        Task<ProductImageStatistics> GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // GET /api/product-images?page=1&limit=24
        // =========================================================

        Task<(
            IEnumerable<ProductImageModel> Items,
            int TotalCount
        )> GetPagedAsync(
            int page,
            int limit);


        // =========================================================
        // SORTING
        // GET /api/product-images?sort=size_desc
        // =========================================================

        Task<IEnumerable<ProductImageModel>> GetSortedAsync(
            string? sort);
    }
}