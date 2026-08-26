using Marketplacesellerportal.Brand.DTOs;
using Marketplacesellerportal.Brand.Interfaces;
using BrandModel = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brand.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BrandResponse>> GetAllAsync()
        {
            var brands = await _repository.GetAllAsync();

            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            });
        }

        public async Task<BrandResponse?> GetByIdAsync(int brandId)
        {
            var brand = await _repository.GetByIdAsync(brandId);

            if (brand == null)
                return null;

            return new BrandResponse
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Description = brand.Description,
                IsActive = brand.IsActive,
                CreatedDate = brand.CreatedDate,
                UpdatedDate = brand.UpdatedDate
            };
        }

        public async Task<IEnumerable<BrandResponse>> GetActiveBrandsAsync()
        {
            var brands = await _repository.GetActiveBrandsAsync();

            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            });
        }

        public async Task<bool> CreateAsync(CreateBrandRequest request)
        {
            var existing = await _repository.GetByNameAsync(request.BrandName);

            if (existing != null)
                return false;

            var brand = new BrandModel
            {
                BrandName = request.BrandName,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = DateTime.Now
            };

            await _repository.AddAsync(brand);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UpdateBrandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.BrandId);

            if (brand == null)
                return false;

            brand.BrandName = request.BrandName;
            brand.Description = request.Description;
            brand.IsActive = request.IsActive;
            brand.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(brand);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int brandId)
        {
            var brand = await _repository.GetByIdAsync(brandId);

            if (brand == null)
                return false;

            await _repository.DeleteAsync(brand);
            await _repository.SaveChangesAsync();

            return true;
        }
        public async Task<BrandStatisticsResponse> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        public async Task<BrandFiltersResponse> GetFiltersAsync()
        {
            return await _repository.GetFiltersAsync();
        }
    }
}
