using Marketplacesellerportal.MarketplaceReturns.DTOs;
using MarketplaceReturnModel =
    Marketplacesellerportal.Models.MarketplaceReturn;

namespace Marketplacesellerportal.MarketplaceReturns.Interfaces
{
    public interface IMarketplaceReturnService
    {
        // =========================================================
        // GET ALL
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetAllAsync();

        // =========================================================
        // GET BY ID
        // =========================================================

        Task<MarketplaceReturnModel?>
            GetByIdAsync(
                int marketplaceReturnId);

        // =========================================================
        // GET BY MARKETPLACE ORDER ITEM
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetByMarketplaceOrderItemIdAsync(
                int marketplaceOrderItemId);

        // =========================================================
        // GET BY SELLER
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetBySellerIdAsync(
                int sellerId);

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetByCustomerIdAsync(
                int customerId);

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetByProductIdAsync(
                int productId);

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        // =========================================================
        // GET BY STATUS
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetByStatusAsync(
                string status);

        // =========================================================
        // GET BY SKU
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetBySKUAsync(
                string sku);

        // =========================================================
        // GET BY RETURN NUMBER
        // =========================================================

        Task<MarketplaceReturnModel?>
            GetByReturnNumberAsync(
                string returnNumber);

        // =========================================================
        // GET BY ORDER ITEM + RETURN
        // =========================================================

        Task<MarketplaceReturnModel?>
            GetMarketplaceReturnAsync(
                int marketplaceOrderItemId,
                int marketplaceReturnId);

        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            SearchAsync(
                string? search);

        // =========================================================
        // STATISTICS
        // =========================================================

        Task<MarketplaceReturnStatistics>
            GetStatisticsAsync();

        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<MarketplaceReturnModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<MarketplaceReturnModel>>
            GetSortedAsync(
                string? sort);

        // =========================================================
        // CREATE
        // =========================================================

        Task<MarketplaceReturnModel>
            CreateAsync(
                MarketplaceReturnModel marketplaceReturn);

        // =========================================================
        // UPDATE
        // =========================================================

        Task<bool>
            UpdateAsync(
                int marketplaceReturnId,
                MarketplaceReturnModel marketplaceReturn);

        // =========================================================
        // DELETE
        // =========================================================

        Task<bool>
            DeleteAsync(
                int marketplaceReturnId);
    }
}
