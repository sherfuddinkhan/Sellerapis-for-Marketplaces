using Marketplacesellerportal.ProductInventories.DTOs;
using Marketplacesellerportal.ProductInventories.Interfaces;

using ProductInventoryEntity =
    Marketplacesellerportal.Models.ProductInventory;

namespace Marketplacesellerportal.ProductInventories.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IProductInventoryRepository _repository;

        public ProductInventoryService(
            IProductInventoryRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetAllAsync()
        {
            var data = await _repository.GetAllAsync();

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductInventoryModel?>
            GetByIdAsync(int productInventoryId)
        {
            var data =
                await _repository.GetByIdAsync(
                    productInventoryId);

            return data == null
                ? null
                : MapToModel(data);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdAsync(int productId)
        {
            var data =
                await _repository.GetByProductIdAsync(
                    productId);

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY PRODUCT IDS
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdsAsync(
                IEnumerable<int> productIds)
        {
            var data =
                await _repository.GetByProductIdsAsync(
                    productIds);

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetBySellerIdAsync(int sellerId)
        {
            var data =
                await _repository.GetBySellerIdAsync(
                    sellerId);

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY WAREHOUSE
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByWarehouseIdAsync(int warehouseId)
        {
            var data =
                await _repository.GetByWarehouseIdAsync(
                    warehouseId);

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            var data =
                await _repository.GetBySellerCustomerAsync(
                    sellerId,
                    customerId);

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET SPECIFIC INVENTORY
        // =========================================================

        public async Task<ProductInventoryModel?>
            GetInventoryAsync(
                int productId,
                int warehouseId,
                int locationId)
        {
            var data =
                await _repository.GetInventoryAsync(
                    productId,
                    warehouseId,
                    locationId);

            return data == null
                ? null
                : MapToModel(data);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductInventoryModel>
            CreateAsync(
                ProductInventoryModel model)
        {
            var entity =
                new ProductInventoryEntity
                {
                    SellerId =
                        model.SellerId,

                    CustomerId =
                        model.CustomerId,

                    ProductId =
                        model.ProductId,

                    WarehouseId =
                        model.WarehouseId,

                    LocationId =
                        model.LocationId,

                    Quantity =
                        model.Quantity,

                    ReservedQuantity =
                        model.ReservedQuantity,

                    DamagedQuantity =
                        model.DamagedQuantity,

                    ReorderLevel =
                        model.ReorderLevel,

                    ReorderQuantity =
                        model.ReorderQuantity,

                    LastStockUpdate =
                        model.LastStockUpdate
                        ?? DateTime.Now,

                    CreatedDate =
                        model.CreatedDate
                        ?? DateTime.Now,

                    UpdatedDate =
                        DateTime.Now
                };

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return MapToModel(entity);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int productInventoryId,
                ProductInventoryModel model)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productInventoryId);

            if (existing == null)
                return false;

            existing.SellerId =
                model.SellerId;

            existing.CustomerId =
                model.CustomerId;

            existing.ProductId =
                model.ProductId;

            existing.WarehouseId =
                model.WarehouseId;

            existing.LocationId =
                model.LocationId;

            existing.Quantity =
                model.Quantity;

            existing.ReservedQuantity =
                model.ReservedQuantity;

            existing.DamagedQuantity =
                model.DamagedQuantity;

            existing.ReorderLevel =
                model.ReorderLevel;

            existing.ReorderQuantity =
                model.ReorderQuantity;

            existing.LastStockUpdate =
                model.LastStockUpdate;

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
                int productInventoryId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productInventoryId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                productInventoryId);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            SearchAsync(
                string? search,
                string? status)
        {
            var data =
                await _repository.SearchAsync(
                    search,
                    status);

            return data.Select(MapToModel);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductInventoryStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<ProductInventoryModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            var result =
                await _repository.GetPagedAsync(
                    page,
                    limit);

            return (
                result.Items.Select(MapToModel),
                result.TotalCount
            );
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<ProductInventoryModel>>
            GetSortedAsync(
                string? sort)
        {
            var data =
                await _repository.GetSortedAsync(
                    sort);

            return data.Select(MapToModel);
        }

        // =========================================================
        // ENTITY -> DTO
        // =========================================================

        private static ProductInventoryModel
            MapToModel(
                ProductInventoryEntity entity)
        {
            return new ProductInventoryModel
            {
                ProductInventoryId =
                    entity.ProductInventoryId,

                SellerId =
                    entity.SellerId,

                CustomerId =
                    entity.CustomerId,

                ProductId =
                    entity.ProductId,

                WarehouseId =
                    entity.WarehouseId,

                LocationId =
                    entity.LocationId,

                Quantity =
                    entity.Quantity,

                ReservedQuantity =
                    entity.ReservedQuantity,

                DamagedQuantity =
                    entity.DamagedQuantity,

                ReorderLevel =
                    entity.ReorderLevel,

                ReorderQuantity =
                    entity.ReorderQuantity,

                LastStockUpdate =
                    entity.LastStockUpdate,

                CreatedDate =
                    entity.CreatedDate,

                UpdatedDate =
                    entity.UpdatedDate
            };
        }
    }
}

