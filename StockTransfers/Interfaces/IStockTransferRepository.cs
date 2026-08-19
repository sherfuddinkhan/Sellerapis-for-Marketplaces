using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockTransfers.Interfaces
{
    public interface IStockTransferRepository
    {
        Task<IEnumerable<StockTransfer>> GetAllAsync();

        Task<StockTransfer?> GetByIdAsync(int stockTransferId);

        Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockTransfer>> GetByProductIdAsync(int productId);

        Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(int fromWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(int toWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByStatusAsync(string status);
        Task<IEnumerable<StockTransfer>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task<StockTransfer?> GetStockTransferAsync(int sellerId,int productId,int stockTransferId);

        Task AddAsync(StockTransfer stockTransfer);

        Task UpdateAsync(StockTransfer stockTransfer);

        Task DeleteAsync(int stockTransferId);

        Task SaveChangesAsync();
    }
}
