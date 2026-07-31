using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockLedgers.Interfaces
{
    public interface IStockLedgerRepository
    {
        Task<IEnumerable<StockLedger>> GetAllAsync();

        Task<StockLedger?> GetByIdAsync(int stockLedgerId);

        Task<IEnumerable<StockLedger>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockLedger>> GetByProductIdAsync(int productId);

        Task<IEnumerable<StockLedger>> GetByWarehouseIdAsync(int warehouseId);

        Task<IEnumerable<StockLedger>> GetByTransactionTypeAsync(string transactionType);

        Task<StockLedger?> GetStockLedgerAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId);

        Task AddAsync(StockLedger stockLedger);

        Task UpdateAsync(StockLedger stockLedger);

        Task DeleteAsync(int stockLedgerId);

        Task SaveChangesAsync();
    }
}
