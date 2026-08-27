using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.DTOs;
using Marketplacesellerportal.StockAdjustments.Interfaces;

namespace Marketplacesellerportal.StockAdjustments.Services
{
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly IStockAdjustmentRepository _repository;

        public StockAdjustmentService(IStockAdjustmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockAdjustment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<StockAdjustment>> SearchAsync(
    string search)
        {
            return await _repository.SearchAsync(search);
        }

        public async Task<IEnumerable<StockAdjustment>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        public async Task<PagedResult<StockAdjustment>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        public async Task<StockAdjustmentStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        public async Task<IEnumerable<StockAdjustment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }
        public async Task<StockAdjustment?> GetByIdAsync(int stockAdjustmentId)
        {
            return await _repository.GetByIdAsync(stockAdjustmentId);
        }

        public async Task<IEnumerable<StockAdjustment>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<StockAdjustment>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<IEnumerable<StockAdjustment>> GetByAdjustmentTypeAsync(string adjustmentType)
        {
            return await _repository.GetByAdjustmentTypeAsync(adjustmentType);
        }

        public async Task<StockAdjustment?> GetStockAdjustmentAsync(int sellerId,int productId,int warehouseId,int stockAdjustmentId)
        {
            return await _repository.GetStockAdjustmentAsync(sellerId,productId,warehouseId,stockAdjustmentId);
        }

        public async Task<StockAdjustment> CreateAsync(StockAdjustment stockAdjustment)
        {
            stockAdjustment.CreatedDate = DateTime.Now;

            if (stockAdjustment.AdjustmentDate == null)
                stockAdjustment.AdjustmentDate = DateTime.Now;
            await _repository.AddAsync(stockAdjustment);
            await _repository.SaveChangesAsync();

            return stockAdjustment;
        }

        public async Task<bool> UpdateAsync(int stockAdjustmentId,StockAdjustment stockAdjustment)
        {
            var existing = await _repository.GetByIdAsync(stockAdjustmentId);

            if (existing == null)
                return false;

            existing.SellerId = stockAdjustment.SellerId;
            existing.ProductId = stockAdjustment.ProductId;
            existing.WarehouseId = stockAdjustment.WarehouseId;
            existing.AdjustmentType = stockAdjustment.AdjustmentType;
            existing.Quantity = stockAdjustment.Quantity;
            existing.Reason = stockAdjustment.Reason;
            existing.AdjustedBy = stockAdjustment.AdjustedBy;
            existing.AdjustmentDate = stockAdjustment.AdjustmentDate;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int stockAdjustmentId)
        {
            var existing = await _repository.GetByIdAsync(stockAdjustmentId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(stockAdjustmentId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
