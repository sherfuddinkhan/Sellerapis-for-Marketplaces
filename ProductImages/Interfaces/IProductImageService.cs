using Marketplacesellerportal.ProductImages.DTOs;

namespace Marketplacesellerportal.ProductImages.Interfaces
{
    public interface IProductImageService
    {
        // =========================================================
        // BASIC CRUD
        // =========================================================

        Task<IEnumerable<ProductImageModel>> GetAllAsync();

        Task<ProductImageModel?> GetByIdAsync(
            int productImageId);

        Task<IEnumerable<ProductImageModel>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductImageModel>> GetPrimaryImagesAsync();

        Task<ProductImageModel?> GetPrimaryImageAsync(
            int productId);

        Task<ProductImageModel> CreateAsync(
            ProductImageModel productImage);

        Task<bool> UpdateAsync(
            int productImageId,
            ProductImageModel productImage);

        Task<bool> DeleteAsync(
            int productImageId);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<ProductImageModel>> SearchAsync(
            string? search);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<ProductImageStatistics> GetStatisticsAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<ProductImageModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<ProductImageModel>> GetSortedAsync(
            string? sort);
    }
}