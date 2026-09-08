using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Marketplacesellerportal.MarketplaceOrderItems.DTOs;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;

using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;

namespace Marketplacesellerportal.MarketplaceOrderItems.Services
{
    public class MarketplaceOrderItemService
        : IMarketplaceOrderItemService
    {
        private readonly IMarketplaceOrderItemRepository
            _repository;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MarketplaceOrderItemService(
            IMarketplaceOrderItemRepository repository)
        {
            _repository = repository;
        }


        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<MarketplaceOrderItemEntity?>
            GetByIdAsync(
                int marketplaceOrderItemId)
        {
            return await _repository.GetByIdAsync(
                marketplaceOrderItemId);
        }


        // =========================================================
        // GET BY MARKETPLACE ORDER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
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

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository
                .GetByProductIdAsync(productId);
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository
                .GetBySellerIdAsync(sellerId);
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository
                .GetByCustomerIdAsync(customerId);
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
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

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetByStatusAsync(
                string status)
        {
            return await _repository
                .GetByStatusAsync(status);
        }


        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
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
            IEnumerable<MarketplaceOrderItemEntity> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (limit < 1)
            {
                limit = 20;
            }

            if (limit > 100)
            {
                limit = 100;
            }

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }


        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItemEntity>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(sort);
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task<MarketplaceOrderItemEntity>
            CreateAsync(
                MarketplaceOrderItemEntity item)
        {
            if (item.CreatedDate == null)
            {
                item.CreatedDate = DateTime.Now;
            }

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
                MarketplaceOrderItemEntity item)
        {
            var existing =
                await _repository.GetByIdAsync(
                    marketplaceOrderItemId);

            if (existing == null)
            {
                return false;
            }


            // -----------------------------------------------------
            // BASIC INFORMATION
            // -----------------------------------------------------

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


            // -----------------------------------------------------
            // ORDER ITEM INFORMATION
            // -----------------------------------------------------

            existing.MarketplaceOrderItemNumber =
                item.MarketplaceOrderItemNumber;

            existing.ExternalOrderItemId =
                item.ExternalOrderItemId;

            existing.ProductTitle =
                item.ProductTitle;

            existing.SKU =
                item.SKU;


            // -----------------------------------------------------
            // QUANTITY / PRICE
            // -----------------------------------------------------

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


            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            existing.Status =
                item.Status;


            // -----------------------------------------------------
            // UPDATE
            // -----------------------------------------------------

            await _repository.UpdateAsync(existing);

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
            {
                return false;
            }

            await _repository.DeleteAsync(
                marketplaceOrderItemId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}