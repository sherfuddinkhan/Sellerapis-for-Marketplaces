using Marketplacesellerportal.Categories.Interfaces;
using Marketplacesellerportal.Category.DTOs;

using CategoryModel = Marketplacesellerportal.Models.Category;

namespace Marketplacesellerportal.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }


        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<CategoryModel?> GetByIdAsync(
            int categoryId)
        {
            return await _repository.GetByIdAsync(categoryId);
        }


        // =========================================================
        // GET BY NAME
        // =========================================================

        public async Task<CategoryModel?> GetByNameAsync(
            string categoryName)
        {
            return await _repository.GetByNameAsync(categoryName);
        }


        // =========================================================
        // GET ACTIVE
        // =========================================================

        public async Task<IEnumerable<CategoryModel>> GetActiveAsync()
        {
            return await _repository.GetActiveAsync();
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task<CategoryModel> CreateAsync(
            CategoryModel category)
        {
            category.CreatedDate = DateTime.Now;
            category.UpdatedDate = null;

            await _repository.AddAsync(category);

            await _repository.SaveChangesAsync();

            return category;
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool> UpdateAsync(
            int categoryId,
            CategoryModel category)
        {
            var existing =
                await _repository.GetByIdAsync(categoryId);

            if (existing == null)
            {
                return false;
            }

            existing.CategoryName =
                category.CategoryName;

            existing.ParentCategoryId =
                category.ParentCategoryId;

            existing.Description =
                category.Description;

            existing.IsActive =
                category.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(existing);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool> DeleteAsync(
            int categoryId)
        {
            var existing =
                await _repository.GetByIdAsync(categoryId);

            if (existing == null)
            {
                return false;
            }

            await _repository.DeleteAsync(existing);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // SEARCH + FILTER + PAGINATION + SORTING
        //
        // GET /api/categories
        // =========================================================

        public async Task<CategoryListResponse> GetCategoriesAsync(
            CategoryListRequest request)
        {
            return await _repository.GetCategoriesAsync(request);
        }


        // =========================================================
        // STATISTICS
        //
        // GET /api/categories/stats
        // =========================================================

        public async Task<CategoryStatisticsResponse>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }
    }
}