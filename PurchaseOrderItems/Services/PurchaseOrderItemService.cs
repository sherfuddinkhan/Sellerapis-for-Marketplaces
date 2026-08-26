using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.DTOs;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;

namespace Marketplacesellerportal.PurchaseOrderItems.Services
{
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IPurchaseOrderItemRepository _repository;

        public PurchaseOrderItemService(
            IPurchaseOrderItemRepository repository)
        {
            _repository = repository;
        }

        // =====================================================
        // GET ALL
        // GET: /api/purchase-order-items
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =====================================================
        // GET BY ID
        // GET: /api/purchase-order-items/{id}
        // =====================================================

        public async Task<PurchaseOrderItem?>
            GetByIdAsync(int purchaseOrderItemId)
        {
            return await _repository.GetByIdAsync(
                purchaseOrderItemId);
        }

        // =====================================================
        // GET BY PURCHASE ORDER
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _repository.GetByPurchaseOrderIdAsync(
                purchaseOrderId);
        }

        // =====================================================
        // GET BY PURCHASE ORDER + ITEM
        // =====================================================

        public async Task<PurchaseOrderItem?>
            GetByPurchaseOrderAndItemIdAsync(
                int purchaseOrderId,
                int purchaseOrderItemId)
        {
            return await _repository
                .GetByPurchaseOrderAndItemIdAsync(
                    purchaseOrderId,
                    purchaseOrderItemId);
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER + PURCHASE ORDERS
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrdersAsync(
                int sellerId,
                int customerId,
                List<int> purchaseOrderIds)
        {
            return await _repository.GetByPurchaseOrdersAsync(
                sellerId,
                customerId,
                purchaseOrderIds);
        }

        // =====================================================
        // SEARCH
        // GET:
        // /api/purchase-order-items?search=sku-882
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            SearchAsync(string? search)
        {
            return await _repository.SearchAsync(search);
        }

        // =====================================================
        // STATISTICS
        // GET:
        // /api/purchase-order-items/stats
        // =====================================================

        public async Task<PurchaseOrderItemStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =====================================================
        // PAGINATION
        // GET:
        // /api/purchase-order-items?page=1&limit=25
        // =====================================================

        public async Task<(
            IEnumerable<PurchaseOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =====================================================
        // SORTING
        // GET:
        // /api/purchase-order-items?sort=line_no
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        // =====================================================
        // CREATE
        // POST:
        // /api/purchase-order-items
        // =====================================================

        public async Task<PurchaseOrderItem>
            CreateAsync(PurchaseOrderItem item)
        {
            await _repository.AddAsync(item);

            await _repository.SaveChangesAsync();

            return item;
        }

        // =====================================================
        // UPDATE
        // PUT:
        // /api/purchase-order-items/{id}
        // =====================================================

        public async Task<bool>
            UpdateAsync(
                int purchaseOrderItemId,
                PurchaseOrderItem item)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseOrderItemId);

            if (existing == null)
                return false;

            existing.ProductId =
                item.ProductId;

            existing.Quantity =
                item.Quantity;

            existing.UnitPrice =
                item.UnitPrice;

            existing.Discount =
                item.Discount;

            existing.TaxAmount =
                item.TaxAmount;

            existing.TotalAmount =
                item.TotalAmount;

            await _repository.UpdateAsync(existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // DELETE
        // DELETE:
        // /api/purchase-order-items/{id}
        // =====================================================

        public async Task<bool>
            DeleteAsync(int purchaseOrderItemId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseOrderItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                purchaseOrderItemId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}