using Marketplacesellerportal.Models;
using Marketplacesellerportal.Products.DTOs;
using Marketplacesellerportal.Products.Interfaces;

namespace Marketplacesellerportal.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL PRODUCTS
        // =========================================================
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(MapToDto);
        }

        // =========================================================
        // GET PRODUCT BY ID
        // =========================================================
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return MapToDto(product);
        }

        // =========================================================
        // CREATE PRODUCT
        // =========================================================
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var existingProduct = await _repository
                .GetBySKUAsync(dto.SKU);

            if (existingProduct != null)
            {
                throw new InvalidOperationException(
                    $"A product with SKU '{dto.SKU}' already exists.");
            }

            var product = new Product
            {
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                ProductName = dto.ProductName,
                SKU = dto.SKU,
                Barcode = dto.Barcode,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                ProductTypeId = dto.ProductTypeId,
                Description = dto.Description,
                Weight = dto.Weight,
                Length = dto.Length,
                Width = dto.Width,
                Height = dto.Height,
                HSNCode = dto.HSNCode,
                UnitOfMeasure = dto.UnitOfMeasure,
                Status = string.IsNullOrWhiteSpace(dto.Status) ? "Active" : dto.Status,
                IsActive = dto.IsActive ?? true,
                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();

            return MapToDto(product);
        }

        // =========================================================
        // UPDATE PRODUCT
        // =========================================================
        public async Task<ProductDto?> UpdateAsync(
            int id,
            UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            product.ProductName = dto.ProductName;
            product.SKU = dto.SKU;
            product.Barcode = dto.Barcode;

            product.BrandId = dto.BrandId;
            product.CategoryId = dto.CategoryId;
            product.ProductTypeId = dto.ProductTypeId;

            product.Description = dto.Description;

            product.Weight = dto.Weight;
            product.Length = dto.Length;
            product.Width = dto.Width;
            product.Height = dto.Height;

            product.HSNCode = dto.HSNCode;
            product.UnitOfMeasure = dto.UnitOfMeasure;

            product.Status = dto.Status;

            if (dto.IsActive.HasValue)
            {
                product.IsActive = dto.IsActive.Value;
            }

            product.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(product);
            await _repository.SaveChangesAsync();

            return MapToDto(product);
        }

        // =========================================================
        // DELETE PRODUCT
        // =========================================================
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return false;

            await _repository.DeleteAsync(product);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // MAP PRODUCT → DTO
        // =========================================================
        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,

                SellerId = product.SellerId,
                CustomerId = product.CustomerId,

                ProductName = product.ProductName,
                SKU = product.SKU,
                Barcode = product.Barcode,

                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ProductTypeId = product.ProductTypeId,

                Description = product.Description,

                Weight = product.Weight,
                Length = product.Length,
                Width = product.Width,
                Height = product.Height,

                HSNCode = product.HSNCode,
                UnitOfMeasure = product.UnitOfMeasure,

                Status = product.Status,

                IsActive = product.IsActive,

                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate
            };
        }
    }
}
