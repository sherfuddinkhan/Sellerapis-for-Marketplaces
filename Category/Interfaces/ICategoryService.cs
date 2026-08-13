
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int categoryId);

        Task<Category?> GetByNameAsync(string categoryName);

        Task<IEnumerable<Category>> GetActiveAsync();

        Task<Category> CreateAsync(Category category);

        Task<bool> UpdateAsync(int categoryId, Category category);

        Task<bool> DeleteAsync(int categoryId);
    }
}

