using Marketplacesellerportal.MarketplaceReturns.DTOs;
using Marketplacesellerportal.MarketplaceReturns.Interfaces;

using MarketplaceReturnModel =
    Marketplacesellerportal.Models.MarketplaceReturn;

namespace Marketplacesellerportal.MarketplaceReturns.Services
{
    public class MarketplaceReturnService
        : IMarketplaceReturnService
    {
        private readonly IMarketplaceReturnRepository _repository;

        public MarketplaceReturnService(
            IMarketplaceReturnRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetByIdAsync(
                int marketplaceReturnId)
        {
            return await _repository.GetByIdAsync(
                marketplaceReturnId);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER ITEM
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByMarketplaceOrderItemIdAsync(
                int marketplaceOrderItemId)
        {
            return await _repository
                .GetByMarketplaceOrderItemIdAsync(
                    marketplaceOrderItemId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository
                .GetByCustomerIdAsync(customerId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository
                .GetByProductIdAsync(productId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
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

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByStatusAsync(
                string status)
        {
            return await _repository
                .GetByStatusAsync(status);
        }

        // =========================================================
        // GET BY SKU
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetBySKUAsync(
                string sku)
        {
            return await _repository
                .GetBySKUAsync(sku);
        }

        // =========================================================
        // GET BY RETURN NUMBER
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetByReturnNumberAsync(
                string returnNumber)
        {
            return await _repository
                .GetByReturnNumberAsync(returnNumber);
        }

        // =========================================================
        // GET BY ORDER ITEM + RETURN
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetMarketplaceReturnAsync(
                int marketplaceOrderItemId,
                int marketplaceReturnId)
        {
            return await _repository
                .GetMarketplaceReturnAsync(
                    marketplaceOrderItemId,
                    marketplaceReturnId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            SearchAsync(
                string? search)
        {
            return await _repository
                .SearchAsync(search);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<MarketplaceReturnStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<MarketplaceReturnModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 20;

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<MarketplaceReturnModel>
            CreateAsync(
                MarketplaceReturnModel marketplaceReturn)
        {
            marketplaceReturn.CreatedDate =
                DateTime.Now;

            await _repository.AddAsync(
                marketplaceReturn);

            await _repository.SaveChangesAsync();

            return marketplaceReturn;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int marketplaceReturnId,
                MarketplaceReturnModel marketplaceReturn)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceReturnId);

            if (existing == null)
                return false;

            existing.MarketplaceOrderItemId =
                marketplaceReturn.MarketplaceOrderItemId;

            existing.ReturnNumber =
                marketplaceReturn.ReturnNumber;

            existing.ReturnReason =
                marketplaceReturn.ReturnReason;

            existing.ReturnStatus =
                marketplaceReturn.ReturnStatus;

            existing.QuantityReturned =
                marketplaceReturn.QuantityReturned;

            existing.RefundAmount =
                marketplaceReturn.RefundAmount;

            existing.ReturnDate =
                marketplaceReturn.ReturnDate;

            existing.SellerId =
                marketplaceReturn.SellerId;

            existing.CustomerId =
                marketplaceReturn.CustomerId;

            existing.ProductId =
                marketplaceReturn.ProductId;

            existing.SKU =
                marketplaceReturn.SKU;

            existing.UpdatedDate =
                DateTime.Now;

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
                int marketplaceReturnId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceReturnId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                marketplaceReturnId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

