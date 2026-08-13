
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int categoryId);

        Task<Category?> GetByNameAsync(string categoryName);

        Task<IEnumerable<Category>> GetActiveAsync();

        Task AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category);

        Task SaveChangesAsync();
    }
}

