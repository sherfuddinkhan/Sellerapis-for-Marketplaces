using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.Catalog.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>> GetProductsAsync(
            int sellerId,
            int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET PRODUCT DETAILS
        // =========================================================
        public async Task<ProductDetailsResponse?> GetProductDetailsAsync(
            int productId,
            int sellerId,
            int customerId)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p =>
                    p.ProductId == productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId);

            if (product == null)
                return null;

            var products = await BuildProductResponsesAsync(
                new List<Product> { product },
                sellerId,
                customerId);

            var catalogProduct = products.FirstOrDefault();

            if (catalogProduct == null)
                return null;

            return new ProductDetailsResponse
            {
                Product = catalogProduct,

                Images = (await GetProductImagesAsync(
                    productId,
                    sellerId,
                    customerId)).ToList(),

                Attributes = (await GetProductAttributesAsync(
                    productId,
                    sellerId,
                    customerId)).ToList(),

                Reviews = (await GetProductReviewsAsync(
                    productId,
                    sellerId,
                    customerId)).ToList(),

                RelatedProducts = (await GetRelatedProductsAsync(
                    productId,
                    sellerId,
                    customerId)).ToList()
            };
        }


        // =========================================================
        // CREATE PRODUCT
        // =========================================================
        public async Task<Product> CreateProductAsync(
            CreateProductRequest request)
        {
            var product = new Product
            {
                SellerId = request.SellerId,
                CustomerId = request.CustomerId,

                SKU = request.SKU,
                ProductName = request.ProductName,
                Description = request.Description,

                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                ProductTypeId = request.ProductTypeId,

                Barcode = request.Barcode,
                HSNCode = request.HSNCode,
                UnitOfMeasure = request.UnitOfMeasure,

                Weight = request.Weight,
                Length = request.Length,
                Width = request.Width,
                Height = request.Height,

                Status = string.IsNullOrWhiteSpace(request.Status)
                    ? "Active"
                    : request.Status,

                IsActive = request.IsActive ?? true,

                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }


        // =========================================================
        // SEARCH PRODUCTS
        // =========================================================
 public async Task<IEnumerable<CatalogProductResponse>> SearchProductsAsync(ProductSearchRequest request,int sellerId,int customerId)
        {
            var query = _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true)
                .AsQueryable();

            if (request != null)
            {
                // Search by product name
                if (!string.IsNullOrWhiteSpace(request.SearchText))
                {
                    query = query.Where(p =>
                        p.ProductName.Contains(request.SearchText));
                }

                // Brand
                if (request.BrandId.HasValue &&
                    request.BrandId.Value > 0)
                {
                    query = query.Where(p =>
                        p.BrandId == request.BrandId.Value);
                }

                // Category
                if (request.CategoryId.HasValue &&
                    request.CategoryId.Value > 0)
                {
                    query = query.Where(p =>
                        p.CategoryId == request.CategoryId.Value);
                }

                // Product Type
                if (request.ProductTypeId.HasValue &&
                    request.ProductTypeId.Value > 0)
                {
                    query = query.Where(p =>
                        p.ProductTypeId == request.ProductTypeId.Value);
                }
            }

            var pageNumber =
                request != null && request.PageNumber > 0
                    ? request.PageNumber
                    : 1;

            var pageSize =
                request != null && request.PageSize > 0
                    ? request.PageSize
                    : 20;

            var products = await query
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET PRODUCTS BY BRAND
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetProductsByBrandAsync(
                int brandId,
                int sellerId,
                int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.BrandId == brandId &&
                    p.IsActive == true)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET PRODUCTS BY CATEGORY
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetProductsByCategoryAsync(int categoryId,int sellerId,int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.CategoryId == categoryId &&
                    p.IsActive == true)
                .ToListAsync();
            return await BuildProductResponsesAsync(products,sellerId,customerId);
        }
        // =========================================================
        // GET PRODUCTS BY PRODUCT TYPE
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetProductsByProductTypeAsync(int productTypeId,int sellerId,int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.ProductTypeId == productTypeId &&
                    p.IsActive == true)
                .ToListAsync();

            return await BuildProductResponsesAsync(products,sellerId,customerId);
        }


        // =========================================================
        // GET LATEST PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetLatestProductsAsync(
                int sellerId,
                int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true)
                .OrderByDescending(p => p.CreatedDate)
                .Take(20)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET FEATURED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetFeaturedProductsAsync(
                int sellerId,
                int customerId)
        {
            // Your current Product table does not have IsFeatured.
            // Therefore, latest active products are returned.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true)
                .OrderByDescending(p => p.CreatedDate)
                .Take(20)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET TOP RATED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetTopRatedProductsAsync(
                int sellerId,
                int customerId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true)
                .ToListAsync();

            var responses = await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);

            return responses
                .OrderByDescending(x => x.Rating)
                .Take(20)
                .ToList();
        }


        // =========================================================
        // GET BEST SELLING PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetBestSellingProductsAsync(
                int sellerId,
                int customerId)
        {
            // Order/sales table is not currently connected.
            // Return active products for this seller/customer.

            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true)
                .OrderByDescending(p => p.ProductId)
                .Take(20)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // GET BRANDS
        // =========================================================
        public async Task<IEnumerable<BrandResponse>>
            GetBrandsAsync(
                int sellerId,
                int customerId)
        {
            var brandIds = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.BrandId.HasValue)
                .Select(p => p.BrandId!.Value)
                .Distinct()
                .ToListAsync();

            if (!brandIds.Any())
                return Enumerable.Empty<BrandResponse>();

            var brands = await _context.Brands
                .AsNoTracking()
                .Where(b =>
                    b.IsActive &&
                    brandIds.Contains(b.BrandId))
                .ToListAsync();

            return brands
                .Select(b => new BrandResponse
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName
                })
                .ToList();
        }


        // =========================================================
        // GET CATEGORIES
        // =========================================================
        public async Task<IEnumerable<CategoryResponse>>
            GetCategoriesAsync(
                int sellerId,
                int customerId)
        {
            var categoryIds = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.CategoryId.HasValue)
                .Select(p => p.CategoryId!.Value)
                .Distinct()
                .ToListAsync();

            if (!categoryIds.Any())
                return Enumerable.Empty<CategoryResponse>();

            var categories = await _context.Categories
                .AsNoTracking()
                .Where(c =>
                    c.IsActive &&
                    categoryIds.Contains(c.CategoryId))
                .ToListAsync();

            return categories
                .Select(c => new CategoryResponse
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                })
                .ToList();
        }

        // =========================================================
        // GET PRODUCT IMAGES
        // =========================================================
        public async Task<IEnumerable<ProductImageResponse>>
            GetProductImagesAsync(
                int productId,
                int sellerId,
                int customerId)
        {
            var productExists = await _context.Products
                .AsNoTracking()
                .AnyAsync(p =>
                    p.ProductId == productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId);

            if (!productExists)
                return Enumerable.Empty<ProductImageResponse>();

            var images = await _context.ProductImages
                .AsNoTracking()
                .Where(x =>
                    x.ProductId == productId &&
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            return images
                .Select(x => new ProductImageResponse
                {
                    ProductImageId = x.ProductImageId,
                    ProductId = x.ProductId,
                    ImageUrl = x.ImageUrl ?? "",
                    DisplayOrder = x.DisplayOrder ?? 0,
                    IsPrimary = x.IsPrimary ?? false
                })
                .ToList();
        }


        // =========================================================
        // GET PRODUCT ATTRIBUTES
        // =========================================================
        public async Task<IEnumerable<ProductAttributeResponse>>
            GetProductAttributesAsync(
                int productId,
                int sellerId,
                int customerId)
        {
            var productExists = await _context.Products
                .AsNoTracking()
                .AnyAsync(p =>
                    p.ProductId == productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId);

            if (!productExists)
                return Enumerable.Empty<ProductAttributeResponse>();

            var attributes = await _context.ProductAttributes
                .AsNoTracking()
                .Where(x =>
                    x.ProductId == productId)
                .ToListAsync();

            return attributes
                .Select(x => new ProductAttributeResponse
                {
                    ProductAttributeId = x.ProductAttributeId,
                    ProductId = x.ProductId,
                    AttributeName = x.AttributeName,
                    AttributeValue = x.AttributeValue
                })
                .ToList();
        }

        // =========================================================
        // GET PRODUCT REVIEWS
        // =========================================================
        // =========================================================
        // GET PRODUCT REVIEWS
        // =========================================================
        public async Task<IEnumerable<ProductReviewResponse>>
            GetProductReviewsAsync(
                int productId,
                int sellerId,
                int customerId)
        {
            var productExists = await _context.Products
                .AsNoTracking()
                .AnyAsync(p =>
                    p.ProductId == productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId);

            if (!productExists)
                return Enumerable.Empty<ProductReviewResponse>();

            var reviews = await _context.Reviews
                .AsNoTracking()
                .Where(x =>
                    x.ProductId == productId &&
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return reviews
                .Select(x => new ProductReviewResponse
                {
                    ReviewId = x.ReviewId,

                    CustomerId = x.CustomerId,

                    ProductId = x.ProductId,

                    Rating = x.Rating,

                    ReviewText = x.ReviewText ?? "",

                    CreatedDate = x.CreatedDate ?? DateTime.Now
                })
                .ToList();
        }


        // =========================================================
        // GET RELATED PRODUCTS
        // =========================================================
        public async Task<IEnumerable<CatalogProductResponse>>
            GetRelatedProductsAsync(
                int productId,
                int sellerId,
                int customerId)
        {
            var currentProduct = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p =>
                    p.ProductId == productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId);

            if (currentProduct == null)
                return Enumerable.Empty<CatalogProductResponse>();

            var products = await _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.ProductId != productId &&
                    p.SellerId == sellerId &&
                    p.CustomerId == customerId &&
                    p.IsActive == true &&
                    p.CategoryId == currentProduct.CategoryId)
                .OrderByDescending(p => p.ProductId)
                .Take(10)
                .ToListAsync();

            return await BuildProductResponsesAsync(
                products,
                sellerId,
                customerId);
        }


        // =========================================================
        // COMMON PRODUCT RESPONSE BUILDER
        // =========================================================
        private async Task<List<CatalogProductResponse>>
            BuildProductResponsesAsync(
                List<Product> products,
                int sellerId,
                int customerId)
        {
            if (!products.Any())
                return new List<CatalogProductResponse>();

            var productIds = products
                .Select(p => p.ProductId)
                .ToList();


            // =====================================================
            // PRODUCT PRICES
            // =====================================================
            // IMPORTANT:
            // We intentionally DO NOT use x.SellerId here.
            //
            // Your SQL error was:
            // Invalid column name 'SellerId'
            //
            // The product itself is already restricted by:
            // SellerId + CustomerId.
            //
            var prices = await _context.ProductPrices
     .AsNoTracking()
     .Where(x =>
         productIds.Contains(x.ProductId) &&
         x.SellerId == sellerId &&
         x.CustomerId == customerId &&
         x.IsActive == true)
     .ToListAsync();


            // =====================================================
            // PRODUCT INVENTORY
            // =====================================================
            // Same principle:
            // do not reference Inventory.SellerId unless the
            // database table actually contains that column.
            //
      var inventories = await _context.ProductInventory.AsNoTracking()
         .Where(x =>
             productIds.Contains(x.ProductId) &&
             x.SellerId == sellerId &&
             x.CustomerId == customerId)
         .ToListAsync();

            // =====================================================
            // PRODUCT IMAGES
            // =====================================================
            var images = await _context.ProductImages
                .AsNoTracking()
                .Where(x =>
                    productIds.Contains(x.ProductId))
                .ToListAsync();


            // =====================================================
            // PRODUCT REVIEWS
            // =====================================================
            var reviews = await _context.Reviews
                .AsNoTracking()
                .Where(x =>
                    productIds.Contains(x.ProductId) &&
                    x.CustomerId == customerId)
                .ToListAsync();


            // =====================================================
            // BRANDS
            // =====================================================
            var brands = await _context.Brands
                .AsNoTracking()
                .ToListAsync();


            // =====================================================
            // CATEGORIES
            // =====================================================
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();


            // =====================================================
            // PRODUCT TYPES
            // =====================================================
            var productTypes = await _context.ProductTypes
                .AsNoTracking()
                .ToListAsync();


            // =====================================================
            // BUILD RESPONSE
            // =====================================================
            return products
                .Select(product =>
                {
                    // ---------------------------------------------
                    // PRICES FOR THIS PRODUCT
                    // ---------------------------------------------
                    var productPrices = prices
                        .Where(x =>
                            x.ProductId == product.ProductId)
                        .ToList();


                    // ---------------------------------------------
                    // NORMAL PRICE
                    // ---------------------------------------------
                    var normalPrice = productPrices
                        .Where(x =>
                            !string.Equals(
                                x.PriceType,
                                "Offer",
                                StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(x => x.EffectiveFrom)
                        .FirstOrDefault();


                    // ---------------------------------------------
                    // OFFER PRICE
                    // ---------------------------------------------
                    var offerPrice = productPrices
                        .Where(x =>
                            string.Equals(
                                x.PriceType,
                                "Offer",
                                StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(x => x.EffectiveFrom)
                        .FirstOrDefault();


                    // ---------------------------------------------
                    // STOCK
                    // ---------------------------------------------
                    var stock = inventories
                        .Where(x =>
                            x.ProductId == product.ProductId)
                        .Sum(x =>
                            x.Quantity ?? 0);


                    // ---------------------------------------------
                    // PRIMARY IMAGE
                    // ---------------------------------------------
                    var primaryImage = images
                        .Where(x =>
                            x.ProductId == product.ProductId)
                        .OrderByDescending(x =>
                            x.IsPrimary == true)
                        .ThenBy(x =>
                            x.DisplayOrder)
                        .FirstOrDefault();


                    // ---------------------------------------------
                    // REVIEWS
                    // ---------------------------------------------
                    var productReviews = reviews
                        .Where(x =>
                            x.ProductId == product.ProductId)
                        .ToList();


                    // ---------------------------------------------
                    // BRAND
                    // ---------------------------------------------
                    var brand = brands
                        .FirstOrDefault(x =>
                            x.BrandId == product.BrandId);


                    // ---------------------------------------------
                    // CATEGORY
                    // ---------------------------------------------
                    var category = categories
                        .FirstOrDefault(x =>
                            x.CategoryId == product.CategoryId);


                    // ---------------------------------------------
                    // PRODUCT TYPE
                    // ---------------------------------------------
                    var productType = productTypes
                        .FirstOrDefault(x =>
                            x.ProductTypeId == product.ProductTypeId);


                    // ---------------------------------------------
                    // FINAL PRODUCT RESPONSE
                    // ---------------------------------------------
                    return new CatalogProductResponse
                    {
                        ProductId = product.ProductId,

                        ProductName = product.ProductName,

                        BrandName =
                            brand?.BrandName ?? "",

                        CategoryName =
                            category?.CategoryName ?? "",

                        ProductType =
                            productType?.ProductTypeName ?? "",

                        Price =
                            normalPrice?.Price ?? 0,

                        OfferPrice =
                            offerPrice?.Price,

                        StockQuantity =
                            (int)stock,

                        PrimaryImage =
                            primaryImage?.ImageUrl,

                        Rating =
                            productReviews.Any()
                                ? productReviews.Average(
                                    x => x.Rating)
                                : 0,

                        ReviewCount =
                            productReviews.Count,

                        IsAvailable =
                            product.IsActive == true &&
                            stock > 0
                    };
                })
                .ToList();
        }
    }
}