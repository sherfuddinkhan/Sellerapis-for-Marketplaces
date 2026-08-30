using Marketplacesellerportal.BrandModel.DTOs;
using Marketplacesellerportal.BrandModel.Interfaces;

using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

namespace Marketplacesellerportal.BrandModel.Services
{
    public class BrandModelService
        : IBrandModelService
    {
        private readonly IBrandModelRepository
            _repository;

        public BrandModelService(
            IBrandModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BrandModelEntity>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BrandModelEntity?>
            GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<BrandModelEntity>>
            GetByBrandIdAsync(int brandId)
        {
            return await _repository
                .GetByBrandIdAsync(brandId);
        }

        public async Task<BrandModelEntity>
            CreateAsync(BrandModelDto dto)
        {
            var model =
                new BrandModelEntity
                {
                    BrandId = dto.BrandId,
                    ModelName = dto.ModelName,
                    Description = dto.Description,
                    IsActive = dto.IsActive,
                    CreatedDate = DateTime.Now
                };

            return await _repository
                .CreateAsync(model);
        }

        public async Task<BrandModelEntity?>
            UpdateAsync(
                int id,
                BrandModelDto dto)
        {
            var existing =
                await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.BrandId =
                dto.BrandId;

            existing.ModelName =
                dto.ModelName;

            existing.Description =
                dto.Description;

            existing.IsActive =
                dto.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            return await _repository
                .UpdateAsync(id, existing);
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var existing =
                await _repository.GetByIdAsync(id);

            if (existing == null)
                return false;

            return await _repository
                .DeleteAsync(id);
        }
    }
}

