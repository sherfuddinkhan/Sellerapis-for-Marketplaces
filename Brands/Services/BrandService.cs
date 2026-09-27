using Marketplacesellerportal.Brands.DTOs;
using Marketplacesellerportal.Brands.Interfaces;
using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        public BrandService(IBrandRepository repository) => _repository = repository;

        public async Task<IEnumerable<BrandResponse>> GetAllAsync()
        {
            var brands = await _repository.GetAllAsync();
            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandCode = x.BrandCode,
                BrandName = x.BrandName,
                Description = x.Description,
                IsActive = x.IsActive,
                ProductCount = x.Products.Count,
                ModelCount = x.BrandModels.Count
            });
        }

        public async Task<BrandResponse?> GetByIdAsync(int brandId)
        {
            var brand = await _repository.GetByIdAsync(brandId);
            if (brand == null) return null;
            return new BrandResponse
            {
                BrandId = brand.BrandId,
                BrandCode = brand.BrandCode,
                BrandName = brand.BrandName,
                Description = brand.Description,
                IsActive = brand.IsActive,
                ProductCount = brand.Products.Count,
                ModelCount = brand.BrandModels.Count
            };
        }

        public async Task<IEnumerable<BrandResponse>> GetActiveBrandsAsync()
        {
            var brands = await _repository.GetActiveBrandsAsync();
            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandCode = x.BrandCode,
                BrandName = x.BrandName,
                IsActive = x.IsActive
            });
        }

        public async Task<bool> CreateAsync(CreateBrandRequest request)
        {
            var existing = await _repository.GetByNameAsync(request.BrandName);
            if (existing != null) return false;
            var brand = new BrandEntity
            {
                BrandCode = request.BrandCode,
                BrandName = request.BrandName,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = DateTime.UtcNow
            };
            await _repository.AddAsync(brand);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateBrandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.BrandId);
            if (brand == null) return false;
            brand.BrandCode = request.BrandCode;
            brand.BrandName = request.BrandName;
            brand.Description = request.Description;
            brand.IsActive = request.IsActive;
            brand.UpdatedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(brand);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int brandId)
        {
            var brand = await _repository.GetByIdAsync(brandId);
            if (brand == null) return false;
            await _repository.DeleteAsync(brand);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<BrandStatisticsResponse> GetStatisticsAsync() => await _repository.GetStatisticsAsync();
        public async Task<BrandFiltersResponse> GetFiltersAsync() => await _repository.GetFiltersAsync();
    }
}