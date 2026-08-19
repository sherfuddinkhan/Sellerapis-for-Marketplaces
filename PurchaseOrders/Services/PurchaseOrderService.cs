using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrders.Interfaces;
using Marketplacesellerportal.PurchaseOrders.Repositories;

namespace Marketplacesellerportal.PurchaseOrders.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;

        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int purchaseOrderId)
        {
            return await _repository.GetByIdAsync(purchaseOrderId);
        }

        // =====================================================
        // GET PURCHASE ORDERS BY SELLER + CUSTOMER
        // =====================================================
        public async Task<IEnumerable<PurchaseOrder>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetBySupplierIdAsync(
            int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }

        // =====================================================
        // CREATE
        // =====================================================
        public async Task<PurchaseOrder> CreateAsync(
            PurchaseOrder purchaseOrder)
        {
            purchaseOrder.CreatedDate = DateTime.Now;

            await _repository.AddAsync(purchaseOrder);
            await _repository.SaveChangesAsync();

            return purchaseOrder;
        }

        // =====================================================
        // GET BY SELLER + PURCHASE ORDER
        // =====================================================
        public async Task<PurchaseOrder?>
            GetBySellerAndPurchaseOrderIdAsync(
                int sellerId,
                int purchaseOrderId)
        {
            return await _repository.GetBySellerAndPurchaseOrderIdAsync(
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
        // UPDATE
        // =====================================================
        public async Task<bool> UpdateAsync(
            int purchaseOrderId,
            PurchaseOrder purchaseOrder)
        {
            var existing =
                await _repository.GetByIdAsync(purchaseOrderId);

            if (existing == null)
                return false;

            existing.SupplierId = purchaseOrder.SupplierId;
            existing.PurchaseOrderNumber =
                purchaseOrder.PurchaseOrderNumber;
            existing.OrderDate = purchaseOrder.OrderDate;
            existing.ExpectedDeliveryDate =
                purchaseOrder.ExpectedDeliveryDate;
            existing.Status = purchaseOrder.Status;
            existing.TotalAmount = purchaseOrder.TotalAmount;
            existing.Remarks = purchaseOrder.Remarks;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // DELETE
        // =====================================================
        public async Task<bool> DeleteAsync(int purchaseOrderId)
        {
            var existing =
                await _repository.GetByIdAsync(purchaseOrderId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(purchaseOrderId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}