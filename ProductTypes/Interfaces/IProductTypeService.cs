using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductTypes.Interfaces
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAllAsync();

        Task<ProductType?> GetByIdAsync(int productTypeId);

        Task<ProductType?> GetByNameAsync(string productTypeName);

        Task<IEnumerable<ProductType>> GetActiveAsync();

        Task<ProductType> CreateAsync(ProductType productType);

        Task<bool> UpdateAsync(int productTypeId, ProductType productType);

        Task<bool> DeleteAsync(int productTypeId);
    }
}
