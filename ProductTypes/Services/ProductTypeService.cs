
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.DTOs;
using Marketplacesellerportal.ProductTypes.Interfaces;

namespace Marketplacesellerportal.ProductTypes.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypeService(
            IProductTypeRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductTypeModel>>
            GetAllAsync()
        {
            var data =
                await _repository.GetAllAsync();

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductTypeModel?>
            GetByIdAsync(
                int productTypeId)
        {
            var data =
                await _repository.GetByIdAsync(
                    productTypeId);

            if (data == null)
                return null;

            return MapToModel(data);
        }

        // =========================================================
        // GET BY NAME
        // =========================================================

        public async Task<ProductTypeModel?>
            GetByNameAsync(
                string productTypeName)
        {
            var data =
                await _repository.GetByNameAsync(
                    productTypeName);

            if (data == null)
                return null;

            return MapToModel(data);
        }

        // =========================================================
        // GET ACTIVE
        // =========================================================

        public async Task<IEnumerable<ProductTypeModel>>
            GetActiveAsync()
        {
            var data =
                await _repository.GetActiveAsync();

            return data.Select(MapToModel);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<ProductTypeModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            var data =
                await _repository
                    .GetBySellerCustomerAsync(
                        sellerId,
                        customerId);

            return data.Select(MapToModel);
        }

        // =========================================================
        // SEARCH + FILTER
        //
        // ?search=electronic
        // ?status=active
        // ?search=electronic&status=active
        // =========================================================

        public async Task<IEnumerable<ProductTypeModel>>
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

        public async Task<ProductTypeStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<ProductTypeModel> Items,
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
        //
        // name_asc
        // name_desc
        // created_asc
        // created_desc
        // =========================================================

        public async Task<IEnumerable<ProductTypeModel>>
            GetSortedAsync(
                string? sort)
        {
            var data =
                await _repository.GetSortedAsync(
                    sort);

            return data.Select(MapToModel);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductTypeModel>
            CreateAsync(
                ProductTypeModel model)
        {
            // -----------------------------------------------------
            // CHECK DUPLICATE NAME
            // -----------------------------------------------------

            var existing =
                await _repository.GetByNameAsync(
                    model.ProductTypeName);

            if (existing != null)
            {
                throw new InvalidOperationException(
                    $"Product type '{model.ProductTypeName}' already exists.");
            }

            // -----------------------------------------------------
            // DTO → ENTITY
            // -----------------------------------------------------

            var productType = new ProductType
            {
                SellerId =
                    model.SellerId,

                CustomerId =
                    model.CustomerId,

                ProductTypeName =
                    model.ProductTypeName,

                Description =
                    model.Description,

                IsActive =
                    model.IsActive,

                CreatedDate =
                    DateTime.Now,

                UpdatedDate =
                    null
            };

            await _repository.AddAsync(
                productType);

            await _repository.SaveChangesAsync();

            return MapToModel(productType);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<ProductTypeModel?>
            UpdateAsync(
                int productTypeId,
                ProductTypeModel model)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productTypeId);

            if (existing == null)
                return null;

            // -----------------------------------------------------
            // UPDATE FIELDS
            // -----------------------------------------------------

            existing.SellerId =
                model.SellerId;

            existing.CustomerId =
                model.CustomerId;

            existing.ProductTypeName =
                model.ProductTypeName;

            existing.Description =
                model.Description;

            existing.IsActive =
                model.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return MapToModel(existing);
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int productTypeId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productTypeId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                productTypeId);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // ENTITY → DTO
        // =========================================================

        private static ProductTypeModel
            MapToModel(
                ProductType entity)
        {
            return new ProductTypeModel
            {
                ProductTypeId =
                    entity.ProductTypeId,

                SellerId =
                    entity.SellerId,

                CustomerId =
                    entity.CustomerId,

                ProductTypeName =
                    entity.ProductTypeName,

                Description =
                    entity.Description,

                IsActive =
                    entity.IsActive,

                CreatedDate =
                    entity.CreatedDate,

                UpdatedDate =
                    entity.UpdatedDate
            };
        }
    }
}
