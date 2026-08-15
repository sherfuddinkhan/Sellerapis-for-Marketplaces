using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL PRODUCTS
        // =========================================================

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var products = await _service.GetProductsAsync(
                sellerId,
                customerId);

            return Ok(products);
        }

        // =========================================================
        // GET PRODUCT DETAILS
        // =========================================================

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductDetails(
            int id,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result = await _service.GetProductDetailsAsync(
                id,
                sellerId,
                customerId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        [HttpPost("search")]
        public async Task<IActionResult> Search(
            [FromQuery] int sellerId,
            [FromQuery] int customerId,
            [FromBody] ProductSearchRequest request)
        {
            var result = await _service.SearchProductsAsync(
                request,
                sellerId,
                customerId);

            return Ok(result);
        }

        // =========================================================
        // CREATE PRODUCT
        // =========================================================

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(
            CreateProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProduct =
                await _service.CreateProductAsync(request);

            return CreatedAtAction(
                nameof(GetProductDetails),
                new
                {
                    id = createdProduct.ProductId,
                    sellerId = createdProduct.SellerId,
                    customerId = createdProduct.CustomerId
                },
                createdProduct);
        }

        // =========================================================
        // BRANDS
        // =========================================================

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetBrandsAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // CATEGORIES
        // =========================================================

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetCategoriesAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // PRODUCTS BY BRAND
        // =========================================================

        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> ProductsByBrand(
            int brandId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductsByBrandAsync(
                    brandId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // PRODUCTS BY CATEGORY
        // =========================================================

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> ProductsByCategory(
            int categoryId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductsByCategoryAsync(
                    categoryId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // PRODUCTS BY PRODUCT TYPE
        // =========================================================

        [HttpGet("producttype/{productTypeId}")]
        public async Task<IActionResult> ProductsByProductType(
            int productTypeId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductsByProductTypeAsync(
                    productTypeId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // LATEST
        // =========================================================

        [HttpGet("latest")]
        public async Task<IActionResult> LatestProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetLatestProductsAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // FEATURED
        // =========================================================

        [HttpGet("featured")]
        public async Task<IActionResult> FeaturedProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetFeaturedProductsAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // TOP RATED
        // =========================================================

        [HttpGet("toprated")]
        public async Task<IActionResult> TopRatedProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetTopRatedProductsAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // BEST SELLERS
        // =========================================================

        [HttpGet("bestsellers")]
        public async Task<IActionResult> BestSellingProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetBestSellingProductsAsync(
                    sellerId,
                    customerId));
        }

        // =========================================================
        // IMAGES
        // =========================================================

        [HttpGet("{productId}/images")]
        public async Task<IActionResult> Images(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductImagesAsync(
                    productId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // ATTRIBUTES
        // =========================================================

        [HttpGet("{productId}/attributes")]
        public async Task<IActionResult> Attributes(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductAttributesAsync(
                    productId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // REVIEWS
        // =========================================================

        [HttpGet("{productId}/reviews")]
        public async Task<IActionResult> Reviews(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetProductReviewsAsync(
                    productId,
                    sellerId,
                    customerId));
        }

        // =========================================================
        // RELATED PRODUCTS
        // =========================================================

        [HttpGet("{productId}/related")]
        public async Task<IActionResult> RelatedProducts(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            return Ok(
                await _service.GetRelatedProductsAsync(
                    productId,
                    sellerId,
                    customerId));
        }
    }
}