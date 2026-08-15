using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductAttributes.Interfaces
{
    public interface IProductAttributeRepository
    {
        Task<IEnumerable<ProductAttribute>> GetAllAsync();

        Task<ProductAttribute?> GetByIdAsync(
            int productAttributeId);

        Task<IEnumerable<ProductAttribute>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductAttribute>> GetBySellerIdAsync(
            int sellerId);

        // ADD THIS
        Task<IEnumerable<ProductAttribute>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);
        Task<IEnumerable<ProductAttribute>> GetByAttributeNameAsync(
    string attributeName);
        Task AddAsync(ProductAttribute productAttribute);

        Task UpdateAsync(ProductAttribute productAttribute);

        Task DeleteAsync(int productAttributeId);

        Task SaveChangesAsync();
    }
}
