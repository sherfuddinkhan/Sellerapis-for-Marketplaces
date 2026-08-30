
using Marketplacesellerportal.BrandModel.DTOs;

using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

namespace Marketplacesellerportal.BrandModel.Interfaces
{
    public interface IBrandModelService
    {
        Task<List<BrandModelEntity>> GetAllAsync();

        Task<BrandModelEntity?> GetByIdAsync(
            int id);

        Task<List<BrandModelEntity>>
            GetByBrandIdAsync(int brandId);

        Task<BrandModelEntity> CreateAsync(
            BrandModelDto dto);

        Task<BrandModelEntity?> UpdateAsync(
            int id,
            BrandModelDto dto);

        Task<bool> DeleteAsync(int id);
    }
}

