using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.ProductPrices.Interfaces
{
    public interface IProductPriceService
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

        Task<ProductPrice> CreateAsync(ProductPrice productPrice);

        Task<bool> UpdateAsync(int productPriceId, ProductPrice productPrice);

        Task<bool> DeleteAsync(int productPriceId);
    }
}
