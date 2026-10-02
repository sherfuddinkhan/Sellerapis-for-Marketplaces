using Marketplacesellerportal.Brands.DTOs;
using Marketplacesellerportal.Brands.Interfaces;

using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public BrandService(
            IBrandRepository repository)
        {
            _repository = repository;
        }


        // =========================================================
        // GET ALL BRANDS
        // =========================================================

        public async Task<IEnumerable<BrandResponse>>
            GetAllAsync()
        {
            var brands =
                await _repository.GetAllAsync();

            return brands.Select(x => new BrandResponse
            {
                BrandId =
                    x.BrandId,

                BrandCode =
                    x.BrandCode,

                BrandName =
                    x.BrandName,

                Description =
                    x.Description,

                // Brand.IsActive is bool?
                // BrandResponse.IsActive is bool
                IsActive =
                    x.IsActive ?? false,

                ProductCount =
                    x.Products?.Count ?? 0,

                ModelCount =
                    x.BrandModels?.Count ?? 0
            });
        }


        // =========================================================
        // GET BRAND BY ID
        // =========================================================

        public async Task<BrandResponse?>
            GetByIdAsync(int brandId)
        {
            var brand =
                await _repository.GetByIdAsync(brandId);

            if (brand == null)
                return null;

            return new BrandResponse
            {
                BrandId =
                    brand.BrandId,

                BrandCode =
                    brand.BrandCode,

                BrandName =
                    brand.BrandName,

                Description =
                    brand.Description,

                // bool? -> bool
                IsActive =
                    brand.IsActive ?? false,

                ProductCount =
                    brand.Products?.Count ?? 0,

                ModelCount =
                    brand.BrandModels?.Count ?? 0
            };
        }


        // =========================================================
        // GET ACTIVE BRANDS
        // =========================================================

        public async Task<IEnumerable<BrandResponse>>
            GetActiveBrandsAsync()
        {
            var brands =
                await _repository.GetActiveBrandsAsync();

            return brands.Select(x => new BrandResponse
            {
                BrandId =
                    x.BrandId,

                BrandCode =
                    x.BrandCode,

                BrandName =
                    x.BrandName,

                IsActive =
                    x.IsActive ?? false
            });
        }


        // =========================================================
        // CREATE BRAND
        // =========================================================

        public async Task<bool>
            CreateAsync(CreateBrandRequest request)
        {
            var existing =
                await _repository.GetByNameAsync(
                    request.BrandName);

            if (existing != null)
                return false;


            var brand = new BrandEntity
            {
                BrandCode =
                    request.BrandCode,

                BrandName =
                    request.BrandName,

                Description =
                    request.Description,

                IsActive =
                    request.IsActive,

                CreatedDate =
                    DateTime.UtcNow
            };


            await _repository.AddAsync(brand);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // UPDATE BRAND
        // =========================================================

        public async Task<bool>
            UpdateAsync(UpdateBrandRequest request)
        {
            var brand =
                await _repository.GetByIdAsync(
                    request.BrandId);

            if (brand == null)
                return false;


            brand.BrandCode =
                request.BrandCode;

            brand.BrandName =
                request.BrandName;

            brand.Description =
                request.Description;

            brand.IsActive =
                request.IsActive;

            brand.UpdatedDate =
                DateTime.UtcNow;


            await _repository.UpdateAsync(brand);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // DELETE BRAND
        // =========================================================

        public async Task<bool>
            DeleteAsync(int brandId)
        {
            var brand =
                await _repository.GetByIdAsync(
                    brandId);

            if (brand == null)
                return false;


            await _repository.DeleteAsync(brand);

            await _repository.SaveChangesAsync();

            return true;
        }


        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<BrandStatisticsResponse>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }


        // =========================================================
        // FILTERS
        // =========================================================

        public async Task<BrandFiltersResponse>
            GetFiltersAsync()
        {
            return await _repository
                .GetFiltersAsync();
        }
    }
}