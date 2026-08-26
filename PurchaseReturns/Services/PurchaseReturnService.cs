using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.DTOs;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Services
{
    public class PurchaseReturnService : IPurchaseReturnService
    {
        private readonly IPurchaseReturnRepository _repository;

        public PurchaseReturnService(
            IPurchaseReturnRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<PurchaseReturn?>
            GetByIdAsync(
                int purchaseReturnId)
        {
            return await _repository.GetByIdAsync(
                purchaseReturnId);
        }

        // =========================================================
        // GET BY PURCHASE ORDER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _repository
                .GetByPurchaseOrderIdAsync(
                    purchaseOrderId);
        }

        // =========================================================
        // GET BY SUPPLIER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetBySupplierIdAsync(
                int supplierId)
        {
            return await _repository
                .GetBySupplierIdAsync(
                    supplierId);
        }

        // =========================================================
        // GET BY GOODS RECEIPT NOTE
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetByGoodsReceiptNoteIdAsync(
                int goodsReceiptNoteId)
        {
            return await _repository
                .GetByGoodsReceiptNoteIdAsync(
                    goodsReceiptNoteId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
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

        public async Task<IEnumerable<PurchaseReturn>>
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

        public async Task<IEnumerable<PurchaseReturn>>
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

        public async Task<IEnumerable<PurchaseReturn>>
            GetByStatusAsync(
                string status)
        {
            return await _repository
                .GetByStatusAsync(
                    status);
        }

        // =========================================================
        // GET SPECIFIC PURCHASE RETURN
        // =========================================================

        public async Task<PurchaseReturn?>
            GetPurchaseReturnAsync(
                int purchaseOrderId,
                int supplierId,
                int purchaseReturnId)
        {
            return await _repository
                .GetPurchaseReturnAsync(
                    purchaseOrderId,
                    supplierId,
                    purchaseReturnId);
        }

        // =========================================================
        // SEARCH
        //
        // /api/purchase-returns?search=PR-3120
        // /api/purchase-returns?status=pending_pickup
        // /api/purchase-returns?search=PR-3120&status=pending_pickup
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
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
        //
        // /api/purchase-returns/stats
        // =========================================================

        public async Task<PurchaseReturnStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        //
        // /api/purchase-returns?page=1&limit=10
        // =========================================================

        public async Task<(
            IEnumerable<PurchaseReturn> Items,
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

            return await _repository
                .GetPagedAsync(
                    page,
                    limit);
        }

        // =========================================================
        // SORTING
        //
        // /api/purchase-returns?sort=id_asc
        // /api/purchase-returns?sort=id_desc
        // /api/purchase-returns?sort=status_asc
        // /api/purchase-returns?sort=status_desc
        // =========================================================

        public async Task<IEnumerable<PurchaseReturn>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository
                .GetSortedAsync(
                    sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<PurchaseReturn>
            CreateAsync(
                PurchaseReturn purchaseReturn)
        {
            purchaseReturn.CreatedDate =
                DateTime.Now;

            if (purchaseReturn.ReturnDate == null)
            {
                purchaseReturn.ReturnDate =
                    DateTime.Now;
            }

            if (string.IsNullOrWhiteSpace(
                purchaseReturn.Status))
            {
                purchaseReturn.Status =
                    "pending_pickup";
            }

            await _repository.AddAsync(
                purchaseReturn);

            await _repository.SaveChangesAsync();

            return purchaseReturn;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int purchaseReturnId,
                PurchaseReturn purchaseReturn)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseReturnId);

            if (existing == null)
                return false;

            existing.PurchaseOrderId =
                purchaseReturn.PurchaseOrderId;

            existing.GoodsReceiptNoteId =
                purchaseReturn.GoodsReceiptNoteId;

            existing.SupplierId =
                purchaseReturn.SupplierId;

            existing.PurchaseReturnNumber =
                purchaseReturn.PurchaseReturnNumber;

            existing.ReturnDate =
                purchaseReturn.ReturnDate;

            existing.Reason =
                purchaseReturn.Reason;

            existing.TotalAmount =
                purchaseReturn.TotalAmount;

            existing.Status =
                purchaseReturn.Status;

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
                int purchaseReturnId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    purchaseReturnId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                purchaseReturnId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

