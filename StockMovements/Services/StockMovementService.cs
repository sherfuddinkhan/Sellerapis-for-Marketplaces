using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.DTOs;
using Marketplacesellerportal.StockMovements.Interfaces;
namespace Marketplacesellerportal.StockMovements.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;

        public StockMovementService(IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        public async Task<IEnumerable<StockMovement>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }
        public async Task<IEnumerable<StockMovement>> SearchAsync(
            string search)
        {
            return await _repository.SearchAsync(search);
        }

        public async Task<IEnumerable<StockMovement>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        public async Task<PagedResult<StockMovement>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        public async Task<StockMovementStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        public async Task<StockMovement?> GetByIdAsync(int stockMovementId)
        {
            return await _repository.GetByIdAsync(stockMovementId);
        }

        public async Task<IEnumerable<StockMovement>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType)
        {
            return await _repository.GetByMovementTypeAsync(movementType);
        }

        public async Task<StockMovement?> GetStockMovementAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockMovementId)
        {
            return await _repository.GetStockMovementAsync(
                sellerId,
                productId,
                warehouseId,
                stockMovementId);
        }
       
        public async Task<StockMovement> CreateAsync(StockMovement stockMovement)
        {
            if (stockMovement.MovementDate == null)
                stockMovement.MovementDate = DateTime.Now;

            await _repository.AddAsync(stockMovement);
            await _repository.SaveChangesAsync();

            return stockMovement;
        }

        public async Task<bool> UpdateAsync(
            int stockMovementId,
            StockMovement stockMovement)
        {
            var existing = await _repository.GetByIdAsync(stockMovementId);

            if (existing == null)
                return false;

            existing.SellerId = stockMovement.SellerId;
            existing.ProductId = stockMovement.ProductId;
            existing.WarehouseId = stockMovement.WarehouseId;
            existing.MovementType = stockMovement.MovementType;
            existing.Quantity = stockMovement.Quantity;
            existing.ReferenceTable = stockMovement.ReferenceTable;
            existing.ReferenceId = stockMovement.ReferenceId;
            existing.MovementDate = stockMovement.MovementDate;
            existing.Remarks = stockMovement.Remarks;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int stockMovementId)
        {
            var existing = await _repository.GetByIdAsync(stockMovementId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(stockMovementId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
