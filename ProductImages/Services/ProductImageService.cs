using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductImages.Interfaces;

namespace Marketplacesellerportal.ProductImages.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _repository;

        public ProductImageService(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductImage?> GetByIdAsync(int productImageId)
        {
            return await _repository.GetByIdAsync(productImageId);
        }

        public async Task<IEnumerable<ProductImage>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductImage>> GetPrimaryImagesAsync()
        {
            return await _repository.GetPrimaryImagesAsync();
        }

        public async Task<ProductImage?> GetPrimaryImageAsync(int productId)
        {
            return await _repository.GetPrimaryImageAsync(productId);
        }

        public async Task<ProductImage> CreateAsync(ProductImage productImage)
        {
            productImage.CreatedDate = DateTime.Now;

            if (productImage.DisplayOrder == null)
                productImage.DisplayOrder = 1;

            if (productImage.IsPrimary == null)
                productImage.IsPrimary = false;

            await _repository.AddAsync(productImage);
            await _repository.SaveChangesAsync();

            return productImage;
        }

        public async Task<bool> UpdateAsync(int productImageId, ProductImage productImage)
        {
            var existing = await _repository.GetByIdAsync(productImageId);

            if (existing == null)
                return false;

            existing.ProductId = productImage.ProductId;
            existing.ImageUrl = productImage.ImageUrl;
            existing.DisplayOrder = productImage.DisplayOrder;
            existing.IsPrimary = productImage.IsPrimary;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int productImageId)
        {
            var existing = await _repository.GetByIdAsync(productImageId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productImageId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
