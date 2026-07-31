using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockTransfers.Interfaces;

namespace Marketplacesellerportal.StockTransfers.Services
{
    public class StockTransferService : IStockTransferService
    {
        private readonly IStockTransferRepository _repository;

        public StockTransferService(IStockTransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockTransfer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<StockTransfer?> GetByIdAsync(int stockTransferId)
        {
            return await _repository.GetByIdAsync(stockTransferId);
        }

        public async Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<StockTransfer>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(int fromWarehouseId)
        {
            return await _repository.GetByFromWarehouseIdAsync(fromWarehouseId);
        }

        public async Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(int toWarehouseId)
        {
            return await _repository.GetByToWarehouseIdAsync(toWarehouseId);
        }

        public async Task<IEnumerable<StockTransfer>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<StockTransfer?> GetStockTransferAsync(
            int sellerId,
            int productId,
            int stockTransferId)
        {
            return await _repository.GetStockTransferAsync(
                sellerId,
                productId,
                stockTransferId);
        }

        public async Task<StockTransfer> CreateAsync(StockTransfer stockTransfer)
        {
            stockTransfer.CreatedDate = DateTime.Now;

            if (stockTransfer.TransferDate == null)
                stockTransfer.TransferDate = DateTime.Now;

            await _repository.AddAsync(stockTransfer);
            await _repository.SaveChangesAsync();

            return stockTransfer;
        }

        public async Task<bool> UpdateAsync(
            int stockTransferId,
            StockTransfer stockTransfer)
        {
            var existing = await _repository.GetByIdAsync(stockTransferId);

            if (existing == null)
                return false;

            existing.SellerId = stockTransfer.SellerId;
            existing.ProductId = stockTransfer.ProductId;
            existing.FromWarehouseId = stockTransfer.FromWarehouseId;
            existing.ToWarehouseId = stockTransfer.ToWarehouseId;
            existing.Quantity = stockTransfer.Quantity;
            existing.TransferDate = stockTransfer.TransferDate;
            existing.Status = stockTransfer.Status;
            existing.Remarks = stockTransfer.Remarks;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int stockTransferId)
        {
            var existing = await _repository.GetByIdAsync(stockTransferId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(stockTransferId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}