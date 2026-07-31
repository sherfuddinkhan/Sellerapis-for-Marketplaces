using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.Interfaces;

namespace Marketplacesellerportal.ProductAttributes.Services
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeRepository _repository;

        public ProductAttributeService(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductAttribute>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductAttribute?> GetByIdAsync(int productAttributeId)
        {
            return await _repository.GetByIdAsync(productAttributeId);
        }

        public async Task<IEnumerable<ProductAttribute>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductAttribute>> GetByAttributeNameAsync(string attributeName)
        {
            return await _repository.GetByAttributeNameAsync(attributeName);
        }

        public async Task<ProductAttribute> CreateAsync(ProductAttribute productAttribute)
        {
            productAttribute.CreatedDate = DateTime.Now;

            await _repository.AddAsync(productAttribute);
            await _repository.SaveChangesAsync();

            return productAttribute;
        }

        public async Task<bool> UpdateAsync(int productAttributeId, ProductAttribute productAttribute)
        {
            var existing = await _repository.GetByIdAsync(productAttributeId);

            if (existing == null)
                return false;

            existing.ProductId = productAttribute.ProductId;
            existing.AttributeName = productAttribute.AttributeName;
            existing.AttributeValue = productAttribute.AttributeValue;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int productAttributeId)
        {
            var existing = await _repository.GetByIdAsync(productAttributeId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productAttributeId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
