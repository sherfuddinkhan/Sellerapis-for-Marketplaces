using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.DTOs;
using Marketplacesellerportal.PurchaseOrders.Interfaces;

namespace Marketplacesellerportal.PurchaseOrders.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;

        public PurchaseOrderService(
            IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<PurchaseOrder?> GetByIdAsync(
            int purchaseOrderId)
        {
            return await _repository.GetByIdAsync(
                purchaseOrderId);
        }


        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }


        // =====================================================
        // GET BY SUPPLIER
        // =====================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(
                supplierId);
        }


        // =====================================================
        // GET BY SELLER + PURCHASE ORDER
        // =====================================================

        public async Task<PurchaseOrder?>
            GetBySellerAndPurchaseOrderIdAsync(
                int sellerId,
                int purchaseOrderId)
        {
            return await _repository
                .GetBySellerAndPurchaseOrderIdAsync(
                    sellerId,
                    purchaseOrderId);
        }


        // =====================================================
        // GET BY SELLER + SUPPLIER + PURCHASE ORDER
        // =====================================================

        public async Task<PurchaseOrder?>
            GetBySellerSupplierAndPurchaseOrderIdAsync(
                int sellerId,
                int supplierId,
                int purchaseOrderId)
        {
            return await _repository
                .GetBySellerSupplierAndPurchaseOrderIdAsync(
                    sellerId,
                    supplierId,
                    purchaseOrderId);
        }


        // =====================================================
        // SEARCH
        // GET:
        // /api/purchase-orders?search=PO-5520
        // =====================================================

        public async Task<IEnumerable<PurchaseOrder>>
            SearchAsync(
                string? search)
        {
            return await _repository.SearchAsync(search);
        }


        // =====================================================
        // STATISTICS
        // GET:
        // /api/purchase-orders/stats
        // =====================================================

        public async Task<PurchaseOrderStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }


        // =====================================================
        // PAGINATION
        // GET:
        // /api/purchase-orders?page=1&limit=10
        // =====================================================

        public async Task<(
            IEnumerable<PurchaseOrder> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }


        // =====================================================
        // STATUS
        // GET:
        // /api/purchase-orders?status=pending_approval
        // =====================================================

        public async Task<IEnumerable<PurchaseOrder>>
            GetByStatusAsync(
                string status)
        {
            return await _repository.GetByStatusAsync(
                status);
        }


        // =====================================================
        // CREATE
        // =====================================================

        public async Task<PurchaseOrder> CreateAsync(
            PurchaseOrder purchaseOrder)
        {
            purchaseOrder.CreatedDate = DateTime.Now;

            await _repository.AddAsync(
                purchaseOrder);

            await _repository.SaveChangesAsync();

            return purchaseOrder;
        }


        // =====================================================
        // UPDATE
        // =====================================================

        public async Task<bool> UpdateAsync(
            int purchaseOrderId,
            PurchaseOrder purchaseOrder)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseOrderId);

            if (existing == null)
                return false;

            existing.SupplierId =
                purchaseOrder.SupplierId;

            existing.PurchaseOrderNumber =
                purchaseOrder.PurchaseOrderNumber;

            existing.OrderDate =
                purchaseOrder.OrderDate;

            existing.ExpectedDeliveryDate =
                purchaseOrder.ExpectedDeliveryDate;

            existing.Status =
                purchaseOrder.Status;

            existing.TotalAmount =
                purchaseOrder.TotalAmount;

            existing.Remarks =
                purchaseOrder.Remarks;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetSortedAsync(
    string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }
        // =====================================================
        // DELETE
        // =====================================================

        public async Task<bool> DeleteAsync(
            int purchaseOrderId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseOrderId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                purchaseOrderId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}