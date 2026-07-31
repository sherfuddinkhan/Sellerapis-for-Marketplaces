using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.Interfaces;

namespace Marketplacesellerportal.ProductTypes.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypeService(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductType?> GetByIdAsync(int productTypeId)
        {
            return await _repository.GetByIdAsync(productTypeId);
        }

        public async Task<ProductType?> GetByNameAsync(string productTypeName)
        {
            return await _repository.GetByNameAsync(productTypeName);
        }

        public async Task<IEnumerable<ProductType>> GetActiveAsync()
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<ProductType> CreateAsync(ProductType productType)
        {
            productType.CreatedDate = DateTime.Now;

            await _repository.AddAsync(productType);
            await _repository.SaveChangesAsync();

            return productType;
        }

        public async Task<bool> UpdateAsync(int productTypeId, ProductType productType)
        {
            var existing = await _repository.GetByIdAsync(productTypeId);

            if (existing == null)
                return false;

            existing.ProductTypeName = productType.ProductTypeName;
            existing.Description = productType.Description;
            existing.IsActive = productType.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int productTypeId)
        {
            var existing = await _repository.GetByIdAsync(productTypeId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productTypeId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
