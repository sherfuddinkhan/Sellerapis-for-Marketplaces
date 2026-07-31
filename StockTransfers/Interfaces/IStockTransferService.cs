using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockTransfers.Interfaces
{
    public interface IStockTransferService
    {
        Task<IEnumerable<StockTransfer>> GetAllAsync();

        Task<StockTransfer?> GetByIdAsync(int stockTransferId);

        Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockTransfer>> GetByProductIdAsync(int productId);

        Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(int fromWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(int toWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByStatusAsync(string status);

        Task<StockTransfer?> GetStockTransferAsync(
            int sellerId,
            int productId,
            int stockTransferId);

        Task<StockTransfer> CreateAsync(StockTransfer stockTransfer);

        Task<bool> UpdateAsync(
            int stockTransferId,
            StockTransfer stockTransfer);

        Task<bool> DeleteAsync(int stockTransferId);
    }
}
