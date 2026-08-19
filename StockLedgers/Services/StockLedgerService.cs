using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.Interfaces;

namespace Marketplacesellerportal.StockLedgers.Services
{
    public class StockLedgerService : IStockLedgerService
    {
        private readonly IStockLedgerRepository _repository;

        public StockLedgerService(IStockLedgerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockLedger>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<StockLedger?> GetByIdAsync(int stockLedgerId)
        {
            return await _repository.GetByIdAsync(stockLedgerId);
        }

        public async Task<IEnumerable<StockLedger>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<StockLedger>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<StockLedger>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<IEnumerable<StockLedger>> GetByTransactionTypeAsync(string transactionType)
        {
            return await _repository.GetByTransactionTypeAsync(transactionType);
        }

        public async Task<StockLedger?> GetStockLedgerAsync(int sellerId,int productId,int warehouseId,int stockLedgerId)
        {
          return await _repository.GetStockLedgerAsync(sellerId,productId,warehouseId,stockLedgerId);
        }

        public async Task<StockLedger> CreateAsync(StockLedger stockLedger)
        {
            stockLedger.CreatedDate = DateTime.Now;

            if (stockLedger.TransactionDate == null)
                stockLedger.TransactionDate = DateTime.Now;

            await _repository.AddAsync(stockLedger);
            await _repository.SaveChangesAsync();

            return stockLedger;
        }

        public async Task<bool> UpdateAsync(
            int stockLedgerId,
            StockLedger stockLedger)
        {
            var existing = await _repository.GetByIdAsync(stockLedgerId);

            if (existing == null)
                return false;

            existing.SellerId = stockLedger.SellerId;
            existing.ProductId = stockLedger.ProductId;
            existing.WarehouseId = stockLedger.WarehouseId;
            existing.TransactionType = stockLedger.TransactionType;
            existing.ReferenceNumber = stockLedger.ReferenceNumber;
            existing.Quantity = stockLedger.Quantity;
            existing.BalanceQuantity = stockLedger.BalanceQuantity;
            existing.Remarks = stockLedger.Remarks;
            existing.TransactionDate = stockLedger.TransactionDate;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int stockLedgerId)
        {
            var existing = await _repository.GetByIdAsync(stockLedgerId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(stockLedgerId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}