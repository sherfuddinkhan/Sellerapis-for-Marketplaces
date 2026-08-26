using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.DTOs;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;

namespace Marketplacesellerportal.MarketplaceOrderItems.Services
{
    public class MarketplaceOrderItemService
        : IMarketplaceOrderItemService
    {
        private readonly IMarketplaceOrderItemRepository
            _repository;

        public MarketplaceOrderItemService(
            IMarketplaceOrderItemRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<MarketplaceOrderItem?>
            GetByIdAsync(
                int marketplaceOrderItemId)
        {
            return await _repository
                .GetByIdAsync(
                    marketplaceOrderItemId);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByMarketplaceOrderIdAsync(
                int marketplaceOrderId)
        {
            return await _repository
                .GetByMarketplaceOrderIdAsync(
                    marketplaceOrderId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository
                .GetByProductIdAsync(
                    productId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(
                    sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository
                .GetByCustomerIdAsync(
                    customerId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository
                .GetBySellerCustomerAsync(
                    sellerId,
                    customerId);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByStatusAsync(
                string status)
        {
            return await _repository
                .GetByStatusAsync(status);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            SearchAsync(
                string? search,
                string? status)
        {
            return await _repository
                .SearchAsync(
                    search,
                    status);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<MarketplaceOrderItemStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<MarketplaceOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 20;

            if (limit > 100)
                limit = 100;

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<MarketplaceOrderItem>
            CreateAsync(
                MarketplaceOrderItem item)
        {
            item.CreatedDate =
                DateTime.Now;

            if (string.IsNullOrWhiteSpace(item.Status))
            {
                item.Status = "pending";
            }

            await _repository.AddAsync(item);

            await _repository.SaveChangesAsync();

            return item;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int marketplaceOrderItemId,
                MarketplaceOrderItem item)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceOrderItemId);

            if (existing == null)
                return false;

            existing.MarketplaceOrderId =
                item.MarketplaceOrderId;

            existing.MarketplaceListingId =
                item.MarketplaceListingId;

            existing.ProductId =
                item.ProductId;

            existing.SellerId =
                item.SellerId;

            existing.CustomerId =
                item.CustomerId;

            existing.MarketplaceOrderItemNumber =
                item.MarketplaceOrderItemNumber;

            existing.ExternalOrderItemId =
                item.ExternalOrderItemId;

            existing.ProductTitle =
                item.ProductTitle;

            existing.SKU =
                item.SKU;

            existing.Quantity =
                item.Quantity;

            existing.UnitPrice =
                item.UnitPrice;

            existing.TaxAmount =
                item.TaxAmount;

            existing.ShippingAmount =
                item.ShippingAmount;

            existing.DiscountAmount =
                item.DiscountAmount;

            existing.TotalAmount =
                item.TotalAmount;

            existing.Status =
                item.Status;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int marketplaceOrderItemId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceOrderItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                marketplaceOrderItemId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
