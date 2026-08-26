using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.DTOs;

namespace Marketplacesellerportal.ProductPrices.Interfaces
{
    public interface IProductPriceService
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();

        Task<ProductPrice?> GetByIdAsync(
            int productPriceId);

        Task<IEnumerable<ProductPrice>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<ProductPrice>> SearchAsync(
            string? search,
            decimal? min,
            decimal? max);

        Task<ProductPriceStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<ProductPrice> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<ProductPrice>>
            GetSortedAsync(string? sort);

        Task<ProductPrice>
            CreateAsync(ProductPrice model);

        Task<bool>
            UpdateAsync(
                int productPriceId,
                ProductPrice model);

        Task<bool>
            DeleteAsync(int productPriceId);
    }
}