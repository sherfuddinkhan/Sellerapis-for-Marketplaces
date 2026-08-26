using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.DTOs;
using Marketplacesellerportal.ProductPrices.Interfaces;

namespace Marketplacesellerportal.ProductPrices.Services
{
    public class ProductPriceService
        : IProductPriceService
    {
        private readonly IProductPriceRepository _repository;

        public ProductPriceService(
            IProductPriceRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductPrice?>
            GetByIdAsync(int productPriceId)
        {
            return await _repository.GetByIdAsync(
                productPriceId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(
                productId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            SearchAsync(
                string? search,
                decimal? min,
                decimal? max)
        {
            return await _repository.SearchAsync(
                search,
                min,
                max);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<ProductPriceStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<ProductPrice> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<ProductPrice>>
            GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductPrice>
            CreateAsync(ProductPrice model)
        {
            model.CreatedDate ??= DateTime.Now;
            model.IsActive ??= true;

            await _repository.AddAsync(model);
            await _repository.SaveChangesAsync();

            return model;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int productPriceId,
                ProductPrice model)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productPriceId);

            if (existing == null)
                return false;

            existing.ProductId =
                model.ProductId;

            existing.SellerId =
                model.SellerId;

            existing.CustomerId =
                model.CustomerId;

            existing.PriceType =
                model.PriceType;

            existing.Price =
                model.Price;

            existing.Currency =
                model.Currency;

            existing.EffectiveFrom =
                model.EffectiveFrom;

            existing.EffectiveTo =
                model.EffectiveTo;

            existing.IsActive =
                model.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(int productPriceId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    productPriceId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                productPriceId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}