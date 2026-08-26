using Marketplacesellerportal.ProductImages.DTOs;
using Marketplacesellerportal.ProductImages.Interfaces;
using ProductImageEntity = Marketplacesellerportal.Models.ProductImage;

namespace Marketplacesellerportal.ProductImages.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _repository;

        public ProductImageService(
            IProductImageRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>> GetAllAsync()
        {
            var images = await _repository.GetAllAsync();

            return images.Select(MapToModel);
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<ProductImageModel?> GetByIdAsync(
            int productImageId)
        {
            var image = await _repository.GetByIdAsync(productImageId);

            return image == null
                ? null
                : MapToModel(image);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>>
            GetByProductIdAsync(int productId)
        {
            var images =
                await _repository.GetByProductIdAsync(productId);

            return images.Select(MapToModel);
        }

        // =========================================================
        // GET PRIMARY IMAGES
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>>
            GetPrimaryImagesAsync()
        {
            var images =
                await _repository.GetPrimaryImagesAsync();

            return images.Select(MapToModel);
        }

        // =========================================================
        // GET PRIMARY IMAGE
        // =========================================================

        public async Task<ProductImageModel?>
            GetPrimaryImageAsync(int productId)
        {
            var image =
                await _repository.GetPrimaryImageAsync(productId);

            return image == null
                ? null
                : MapToModel(image);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<ProductImageModel>
            CreateAsync(ProductImageModel model)
        {
            var entity = new ProductImageEntity
            {
                SellerId = model.SellerId,

                CustomerId = model.CustomerId,

                ProductId = model.ProductId,

                ImageSize = model.ImageSize,

                ImageUrl = model.ImageUrl,

                DisplayOrder =
                    model.DisplayOrder ?? 1,

                IsPrimary =
                    model.IsPrimary ?? false,

                IsActive =
                    model.IsActive,

                CreatedDate =
                    model.CreatedDate ?? DateTime.Now
            };

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return MapToModel(entity);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool> UpdateAsync(
            int productImageId,
            ProductImageModel model)
        {
            var existing =
                await _repository.GetByIdAsync(productImageId);

            if (existing == null)
                return false;

            existing.SellerId =
                model.SellerId;

            existing.CustomerId =
                model.CustomerId;

            existing.ProductId =
                model.ProductId;

            existing.ImageSize =
                model.ImageSize;

            existing.ImageUrl =
                model.ImageUrl;

            existing.DisplayOrder =
                model.DisplayOrder;

            existing.IsPrimary =
                model.IsPrimary;

            existing.IsActive =
                model.IsActive;

            await _repository.UpdateAsync(existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool> DeleteAsync(
            int productImageId)
        {
            var existing =
                await _repository.GetByIdAsync(productImageId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productImageId);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // SEARCH
        // GET /api/product-images?search=banner
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>>
            SearchAsync(string? search)
        {
            var images =
                await _repository.SearchAsync(search);

            return images.Select(MapToModel);
        }

        // =========================================================
        // STATISTICS
        // GET /api/product-images/stats
        // =========================================================

        public async Task<ProductImageStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =========================================================
        // PAGINATION
        // GET /api/product-images?page=1&limit=24
        // =========================================================

        public async Task<(
            IEnumerable<ProductImageModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            var result =
                await _repository.GetPagedAsync(
                    page,
                    limit);

            var items =
                result.Items.Select(MapToModel);

            return (
                items,
                result.TotalCount
            );
        }

        // =========================================================
        // SORTING
        // GET /api/product-images?sort=size_desc
        // =========================================================

        public async Task<IEnumerable<ProductImageModel>>
            GetSortedAsync(string? sort)
        {
            var images =
                await _repository.GetSortedAsync(sort);

            return images.Select(MapToModel);
        }

        // =========================================================
        // ENTITY -> MODEL
        // =========================================================

        private static ProductImageModel MapToModel(
            ProductImageEntity image)
        {
            return new ProductImageModel
            {
                ProductImageId =
                    image.ProductImageId,

                SellerId =
                    image.SellerId,

                CustomerId =
                    image.CustomerId,

                ProductId =
                    image.ProductId,

                ImageSize =
                    image.ImageSize,

                ImageUrl =
                    image.ImageUrl,

                DisplayOrder =
                    image.DisplayOrder,

                IsPrimary =
                    image.IsPrimary,

                IsActive =
                    image.IsActive,

                CreatedDate =
                    image.CreatedDate
            };
        }
    }
}