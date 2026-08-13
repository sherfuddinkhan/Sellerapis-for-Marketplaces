
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Categories.Interfaces;

namespace Marketplacesellerportal.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _repository.GetByIdAsync(categoryId);
        }

        public async Task<Category?> GetByNameAsync(string categoryName)
        {
            return await _repository.GetByNameAsync(categoryName);
        }

        public async Task<IEnumerable<Category>> GetActiveAsync()
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<Category> CreateAsync(Category category)
        {
            category.CreatedDate = DateTime.Now;
            category.UpdatedDate = null;

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            return category;
        }

        public async Task<bool> UpdateAsync(
            int categoryId,
            Category category)
        {
            var existing = await _repository.GetByIdAsync(categoryId);

            if (existing == null)
                return false;

            existing.CategoryName = category.CategoryName;
            existing.ParentCategoryId = category.ParentCategoryId;
            existing.Description = category.Description;
            existing.IsActive = category.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            var existing = await _repository.GetByIdAsync(categoryId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

