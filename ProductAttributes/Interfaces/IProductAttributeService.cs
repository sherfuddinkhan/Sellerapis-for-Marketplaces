using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductAttributes.Interfaces
{
    public interface IProductAttributeService
    {
        Task<IEnumerable<ProductAttribute>> GetAllAsync();

        Task<ProductAttribute?> GetByIdAsync(int productAttributeId);

        Task<IEnumerable<ProductAttribute>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductAttribute>> GetByAttributeNameAsync(string attributeName);

        Task<ProductAttribute> CreateAsync(ProductAttribute productAttribute);

        Task<bool> UpdateAsync(int productAttributeId, ProductAttribute productAttribute);

        Task<bool> DeleteAsync(int productAttributeId);
    }
}
