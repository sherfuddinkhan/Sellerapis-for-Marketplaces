using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductPrices.Interfaces;

namespace Marketplacesellerportal.ProductPrices.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IProductPriceRepository _repository;

        public ProductPriceService(IProductPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductPrice?> GetByIdAsync(int productPriceId)
        {
            return await _repository.GetByIdAsync(productPriceId);
        }

        public async Task<IEnumerable<ProductPrice>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductPrice>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<ProductPrice>> GetByPriceTypeAsync(string priceType)
        {
            return await _repository.GetByPriceTypeAsync(priceType);
        }

        public async Task<IEnumerable<ProductPrice>> GetActivePricesAsync()
        {
            return await _repository.GetActivePricesAsync();
        }

        public async Task<ProductPrice?> GetProductPriceAsync(
            int sellerId,
            int productId,
            string priceType)
        {
            return await _repository.GetProductPriceAsync(
                sellerId,
                productId,
                priceType);
        }

        public async Task<ProductPrice> CreateAsync(ProductPrice productPrice)
        {
            productPrice.CreatedDate = DateTime.Now;

            if (productPrice.IsActive == null)
                productPrice.IsActive = true;

            await _repository.AddAsync(productPrice);
            await _repository.SaveChangesAsync();

            return productPrice;
        }

        public async Task<bool> UpdateAsync(int productPriceId, ProductPrice productPrice)
        {
            var existing = await _repository.GetByIdAsync(productPriceId);

            if (existing == null)
                return false;

            existing.ProductId = productPrice.ProductId;
            existing.SellerId = productPrice.SellerId;
            existing.PriceType = productPrice.PriceType;
            existing.Price = productPrice.Price;
            existing.Currency = productPrice.Currency;
            existing.EffectiveFrom = productPrice.EffectiveFrom;
            existing.EffectiveTo = productPrice.EffectiveTo;
            existing.IsActive = productPrice.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int productPriceId)
        {
            var existing = await _repository.GetByIdAsync(productPriceId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productPriceId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}