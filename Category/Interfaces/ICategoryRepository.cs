using Marketplacesellerportal.Category.DTOs;
using CategoryModel = Marketplacesellerportal.Models.Category;

namespace Marketplacesellerportal.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetAllAsync();

        Task<CategoryModel?> GetByIdAsync(int categoryId);

        Task<CategoryModel?> GetByNameAsync(
            string categoryName);

        Task<IEnumerable<CategoryModel>> GetByIdsAsync(
            IEnumerable<int> categoryIds);

        Task<IEnumerable<CategoryModel>> GetActiveAsync();

        Task AddAsync(CategoryModel category);

        Task UpdateAsync(CategoryModel category);

        Task DeleteAsync(CategoryModel category);

        Task SaveChangesAsync();


        // =====================================================
        // SEARCH + FILTER + PAGINATION + SORTING
        // =====================================================

        Task<CategoryListResponse> GetCategoriesAsync(
            CategoryListRequest request);


        // =====================================================
        // STATISTICS
        // =====================================================

        Task<CategoryStatisticsResponse> GetStatisticsAsync();
    }
}