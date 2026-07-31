using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductTypes.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllAsync();

        Task<ProductType?> GetByIdAsync(int productTypeId);

        Task<ProductType?> GetByNameAsync(string productTypeName);

        Task<IEnumerable<ProductType>> GetActiveAsync();

        Task AddAsync(ProductType productType);

        Task UpdateAsync(ProductType productType);

        Task DeleteAsync(int productTypeId);

        Task SaveChangesAsync();
    }
}
