using Marketplacesellerportal.Category.DTOs;
using Marketplacesellerportal.Models;
using CategoryModel = Marketplacesellerportal.Models.Category;

namespace Marketplacesellerportal.Categories.Interfaces
{
    public interface ICategoryService
    {
        // =====================================================
        // EXISTING CATEGORY APIs
        // =====================================================

        Task<IEnumerable<CategoryModel>> GetAllAsync();

        Task<CategoryModel?> GetByIdAsync(
            int categoryId);

        Task<CategoryModel?> GetByNameAsync(
            string categoryName);

        Task<IEnumerable<CategoryModel>> GetActiveAsync();

        Task<CategoryModel> CreateAsync(
            CategoryModel category);

        Task<bool> UpdateAsync(
            int categoryId,
            CategoryModel category);
        // =====================================================
        // GET PRODUCTS BY CATEGORY
        // =====================================================

        Task<bool> DeleteAsync(
            int categoryId);


        // =====================================================
        // SEARCH + FILTER + PAGINATION + SORTING
        // GET /api/categories
        // =====================================================

        Task<CategoryListResponse> GetCategoriesAsync(
            CategoryListRequest request);

        Task<IEnumerable<Product>>
    GetProductsByCategoryAsync(
        int categoryId);
        // =====================================================
        // STATISTICS
        // GET /api/categories/stats
        // =====================================================

        Task<CategoryStatisticsResponse> GetStatisticsAsync();
    }
}