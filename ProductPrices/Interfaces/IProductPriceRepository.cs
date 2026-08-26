using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.DTOs;

namespace Marketplacesellerportal.ProductPrices.Interfaces
{
    public interface IProductPriceRepository
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();

        Task<ProductPrice?> GetByIdAsync(
            int productPriceId);

        Task<IEnumerable<ProductPrice>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductPrice>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<ProductPrice>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task AddAsync(ProductPrice productPrice);

        Task UpdateAsync(ProductPrice productPrice);

        Task DeleteAsync(int productPriceId);

        Task SaveChangesAsync();

        Task<IEnumerable<ProductPrice>> SearchAsync(
            string? search,
            decimal? min,
            decimal? max);

        Task<ProductPriceStatistics> GetStatisticsAsync();

        Task<(
            IEnumerable<ProductPrice> Items,
            int TotalCount)> GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<ProductPrice>> GetSortedAsync(
            string? sort);
    }
}