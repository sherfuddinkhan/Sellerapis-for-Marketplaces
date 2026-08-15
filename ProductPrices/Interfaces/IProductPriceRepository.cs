using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductPrices.Interfaces
{
    public interface IProductPriceRepository
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();

        Task<ProductPrice?> GetByIdAsync(int productPriceId);

        Task<IEnumerable<ProductPrice>> GetByProductIdAsync(int productId);

        Task<IEnumerable<ProductPrice>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<ProductPrice>> GetByPriceTypeAsync(string priceType);

        Task<IEnumerable<ProductPrice>> GetActivePricesAsync();

        Task<ProductPrice?> GetProductPriceAsync(
            int sellerId,
            int productId,
            string priceType);

        // Seller + Customer prices
        Task<IEnumerable<ProductPrice>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task AddAsync(ProductPrice productPrice);

        Task UpdateAsync(ProductPrice productPrice);

        Task DeleteAsync(int productPriceId);

        Task SaveChangesAsync();
    }
}