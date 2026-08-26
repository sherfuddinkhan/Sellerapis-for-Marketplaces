using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.DTOs;
using Marketplacesellerportal.ProductAttributes.Interfaces;

namespace Marketplacesellerportal.ProductAttributes.Services
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeRepository _repository;

        public ProductAttributeService(
            IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductAttribute?>
            GetByIdAsync(
                int productAttributeId)
        {
            return await _repository.GetByIdAsync(
                productAttributeId);
        }
        public async Task<IEnumerable<ProductAttribute>>
    GetBySellerCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }
        // =========================================================
        // GET BY PRODUCT ID
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository.GetByProductIdAsync(
                productId);
        }

        // =========================================================
        // GET BY ATTRIBUTE NAME
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            GetByAttributeNameAsync(
                string attributeName)
        {
            return await _repository.GetByAttributeNameAsync(
                attributeName);
        }

        // =========================================================
        // SEARCH
        // GET /api/product-attributes?search=color
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            SearchAsync(
                string? search)
        {
            return await _repository.SearchAsync(
                search);
        }

        // =========================================================
        // STATISTICS
        // GET /api/product-attributes/stats
        // =========================================================

        public async Task<ProductAttributeStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // GET /api/product-attributes?page=1&limit=15
        // =========================================================

        public async Task<(
            IEnumerable<ProductAttribute> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        // GET /api/product-attributes?sort=name_asc
        // =========================================================

        public async Task<IEnumerable<ProductAttribute>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductAttribute>
            CreateAsync(
                ProductAttribute productAttribute)
        {
            // Keep this ONLY if ProductAttribute has CreatedDate.
            productAttribute.CreatedDate = DateTime.Now;

            await _repository.AddAsync(
                productAttribute);

            await _repository.SaveChangesAsync();

            return productAttribute;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int productAttributeId,
                ProductAttribute productAttribute)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productAttributeId);

            if (existing == null)
                return false;

            existing.ProductId =
                productAttribute.ProductId;

            existing.AttributeName =
                productAttribute.AttributeName;

            existing.AttributeValue =
                productAttribute.AttributeValue;

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
                int productAttributeId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productAttributeId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                productAttributeId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

