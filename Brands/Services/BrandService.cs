using Marketplacesellerportal.Brands.DTOs;
using Marketplacesellerportal.Brands.Interfaces;
using BrandEntity = Marketplacesellerportal.Models.Brand;
using BrandModelEntity = Marketplacesellerportal.Models.BrandModel;

namespace Marketplacesellerportal.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IBrandModelRepository _modelRepo;

        public BrandService(IBrandRepository brandRepo, IBrandModelRepository modelRepo)
        {
            _brandRepo = brandRepo;
            _modelRepo = modelRepo;
        }

        public async Task<IEnumerable<BrandResponse>> GetAllAsync()
        {
            var brands = await _brandRepo.GetAllAsync();
            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandCode = x.BrandCode,
                BrandName = x.BrandName,
                Description = x.Description,
                IsActive = x.IsActive ?? false,
                ProductCount = x.Products?.Count ?? 0,
                ModelCount = x.BrandModels?.Count ?? 0
            });
        }

        public async Task<BrandResponse?> GetByIdAsync(int brandId)
        {
            var brand = await _brandRepo.GetByIdAsync(brandId);
            if (brand == null) return null;
            return new BrandResponse
            {
                BrandId = brand.BrandId,
                BrandCode = brand.BrandCode,
                BrandName = brand.BrandName,
                Description = brand.Description,
                IsActive = brand.IsActive ?? false,
                ProductCount = brand.Products?.Count ?? 0,
                ModelCount = brand.BrandModels?.Count ?? 0
            };
        }

        public async Task<IEnumerable<BrandResponse>> GetActiveBrandsAsync()
        {
            var brands = await _brandRepo.GetActiveBrandsAsync();
            return brands.Select(x => new BrandResponse
            {
                BrandId = x.BrandId,
                BrandCode = x.BrandCode,
                BrandName = x.BrandName,
                Description = x.Description,
                IsActive = x.IsActive ?? false
            });
        }

        public async Task<bool> CreateAsync(CreateBrandRequest request)
        {
            var existing = await _brandRepo.GetByNameAsync(request.BrandName);
            if (existing != null) return false;
            var brand = new BrandEntity
            {
                BrandCode = request.BrandCode,
                BrandName = request.BrandName,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = DateTime.UtcNow
            };
            await _brandRepo.AddAsync(brand);
            await _brandRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateBrandRequest request)
        {
            var brand = await _brandRepo.GetByIdAsync(request.BrandId);
            if (brand == null) return false;
            brand.BrandCode = request.BrandCode;
            brand.BrandName = request.BrandName;
            brand.Description = request.Description;
            brand.IsActive = request.IsActive;
            brand.UpdatedDate = DateTime.UtcNow;
            await _brandRepo.UpdateAsync(brand);
            await _brandRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int brandId)
        {
            var brand = await _brandRepo.GetByIdAsync(brandId);
            if (brand == null) return false;
            await _brandRepo.DeleteAsync(brand);
            await _brandRepo.SaveChangesAsync();
            return true;
        }

        public Task<BrandStatisticsResponse> GetStatisticsAsync() => _brandRepo.GetStatisticsAsync();
        public Task<BrandFiltersResponse> GetFiltersAsync() => _brandRepo.GetFiltersAsync();

        // ===== BRAND MODEL METHODS - FIXED NO?? ON BOOL =====

        public async Task<IEnumerable<BrandModelResponse>> GetModelsByBrandIdAsync(int brandId)
        {
            var models = await _modelRepo.GetByBrandIdAsync(brandId);
            return models.Select(m => new BrandModelResponse
            {
                BrandModelId = m.BrandModelId,
                BrandId = m.BrandId,
                ModelName = m.ModelName!,
                Description = m.Description,
                IsActive = m.IsActive, // <-- NO??, your table is bool not bool?
                CreatedDate = m.CreatedDate
            });
        }

        public async Task<BrandModelResponse?> GetModelByIdAsync(int modelId)
        {
            var m = await _modelRepo.GetByIdAsync(modelId);
            if (m == null) return null;
            return new BrandModelResponse
            {
                BrandModelId = m.BrandModelId,
                BrandId = m.BrandId,
                ModelName = m.ModelName!,
                Description = m.Description,
                IsActive = m.IsActive,
                CreatedDate = m.CreatedDate
            };
        }

        public async Task<BrandModelResponse> CreateModelAsync(int brandId, CreateBrandModelRequest request)
        {
            var entity = new BrandModelEntity
            {
                BrandId = brandId,
                ModelName = request.ModelName,
                Description = request.Description,
                IsActive = request.IsActive,
                CreatedDate = DateTime.UtcNow
            };
            var created = await _modelRepo.AddAsync(entity);
            await _modelRepo.SaveChangesAsync();
            return new BrandModelResponse
            {
                BrandModelId = created.BrandModelId,
                BrandId = created.BrandId,
                ModelName = created.ModelName!,
                IsActive = created.IsActive,
                Description = created.Description
            };
        }

        public async Task<bool> UpdateModelAsync(UpdateBrandModelRequest request)
        {
            var model = await _modelRepo.GetByIdAsync(request.BrandModelId);
            if (model == null) return false;
            model.ModelName = request.ModelName;
            model.Description = request.Description;
            model.IsActive = request.IsActive;
            model.BrandId = request.BrandId;
            model.UpdatedDate = DateTime.UtcNow;
            await _modelRepo.UpdateAsync(model);
            await _modelRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteModelAsync(int modelId)
        {
            var model = await _modelRepo.GetByIdAsync(modelId);
            if (model == null) return false;
            await _modelRepo.DeleteAsync(model);
            await _modelRepo.SaveChangesAsync();
            return true;
        }
    }
}