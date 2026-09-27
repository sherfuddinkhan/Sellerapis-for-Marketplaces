using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.DTOs;
using Marketplacesellerportal.SalesOrderItems.Interfaces;


namespace Marketplacesellerportal.SalesOrderItems.Services
{
    public class SalesOrderItemService : ISalesOrderItemService
    {
        private readonly ISalesOrderItemRepository _repository;

        public SalesOrderItemService(ISalesOrderItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SalesOrderItem>> SearchAsync(
    string? search)
        {
            return await _repository.SearchAsync(search);
        }

        public async Task<SalesOrderItemStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        public async Task<(
            IEnumerable<SalesOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        public async Task<IEnumerable<SalesOrderItem>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }
        public async Task<IEnumerable<SalesOrderItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId)
        {
            return await _repository.GetByIdAsync(salesOrderItemId);
        }

        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(salesOrderId);
        }

        public async Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId)
        {
            return await _repository.GetByProductAsync(productId);
        }

        public async Task<SalesOrderItem> CreateAsync(SalesOrderItem salesOrderItem)
        {
            await _repository.AddAsync(salesOrderItem);
            await _repository.SaveChangesAsync();

            return salesOrderItem;
        }

        public async Task<bool> UpdateAsync(int salesOrderItemId, SalesOrderItem salesOrderItem)
        {
            var existing = await _repository.GetByIdAsync(salesOrderItemId);

            if (existing == null)
                return false;

            // Existing 7
            existing.SalesOrderId = salesOrderItem.SalesOrderId;
            existing.ProductId = salesOrderItem.ProductId;
            existing.Quantity = salesOrderItem.Quantity;
            existing.UnitPrice = salesOrderItem.UnitPrice;
            existing.Discount = salesOrderItem.Discount;
            existing.TaxAmount = salesOrderItem.TaxAmount;
            existing.TotalAmount = salesOrderItem.TotalAmount;

            // TOPAZ fields
            existing.Description = salesOrderItem.Description;
            existing.Uom = salesOrderItem.Uom;
            existing.Hsncode = salesOrderItem.Hsncode;
            existing.GstPer = salesOrderItem.GstPer;
            existing.SgstPer = salesOrderItem.SgstPer;
            existing.SgstAmount = salesOrderItem.SgstAmount;
            existing.CgstPer = salesOrderItem.CgstPer;
            existing.CgstAmount = salesOrderItem.CgstAmount;
            existing.IgstPer = salesOrderItem.IgstPer;
            existing.IgstAmount = salesOrderItem.IgstAmount;
            existing.AfterGSTAmount = salesOrderItem.AfterGSTAmount;
            existing.QuantityAmount = salesOrderItem.QuantityAmount;
            existing.TotalRateBeforeDiscount = salesOrderItem.TotalRateBeforeDiscount;
            existing.TaxType = salesOrderItem.TaxType;
            existing.BrandXID = salesOrderItem.BrandXID;
            existing.ItemXID = salesOrderItem.ItemXID;
            existing.Pid = salesOrderItem.Pid;
            existing.InvoiceXID = salesOrderItem.InvoiceXID;
            existing.Remarks = salesOrderItem.Remarks;

            // UNIWARE 11 - THIS FIXES NULL ISSUE
            existing.Sku = salesOrderItem.Sku ?? existing.Sku;
            existing.ChannelSkuCode = salesOrderItem.ChannelSkuCode ?? existing.ChannelSkuCode;
            existing.ChannelProductId = salesOrderItem.ChannelProductId ?? existing.ChannelProductId;
            existing.VendorSkuCode = salesOrderItem.VendorSkuCode ?? existing.VendorSkuCode;
            existing.FacilityCode = salesOrderItem.FacilityCode ?? existing.FacilityCode;
            existing.Status = salesOrderItem.Status ?? existing.Status;
            existing.FulfillmentStatus = salesOrderItem.FulfillmentStatus ?? existing.FulfillmentStatus;
            existing.Mrp = salesOrderItem.Mrp ?? existing.Mrp;
            existing.SellingPrice = salesOrderItem.SellingPrice ?? existing.SellingPrice;
            existing.ChannelSaleOrderItemCode = salesOrderItem.ChannelSaleOrderItemCode ?? existing.ChannelSaleOrderItemCode;
            existing.PacketNumber = salesOrderItem.PacketNumber ?? existing.PacketNumber;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int salesOrderItemId)
        {
            var existing = await _repository.GetByIdAsync(salesOrderItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(salesOrderItemId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
