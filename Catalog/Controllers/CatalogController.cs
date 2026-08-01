using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Catalog.DTOs;
using Marketplacesellerportal.Catalog.Interfaces;

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

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProductsAsync());
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var result = await _service.GetProductDetailsAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(ProductSearchRequest request)
        {
            return Ok(await _service.SearchProductsAsync(request));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await _service.GetBrandsAsync());
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _service.GetCategoriesAsync());
        }

        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> ProductsByBrand(int brandId)
        {
            return Ok(await _service.GetProductsByBrandAsync(brandId));
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            return Ok(await _service.GetProductsByCategoryAsync(categoryId));
        }

        [HttpGet("producttype/{productTypeId}")]
        public async Task<IActionResult> ProductsByProductType(int productTypeId)
        {
            return Ok(await _service.GetProductsByProductTypeAsync(productTypeId));
        }

        [HttpGet("latest")]
        public async Task<IActionResult> LatestProducts()
        {
            return Ok(await _service.GetLatestProductsAsync());
        }

        [HttpGet("featured")]
        public async Task<IActionResult> FeaturedProducts()
        {
            return Ok(await _service.GetFeaturedProductsAsync());
        }

        [HttpGet("toprated")]
        public async Task<IActionResult> TopRatedProducts()
        {
            return Ok(await _service.GetTopRatedProductsAsync());
        }

        [HttpGet("bestsellers")]
        public async Task<IActionResult> BestSellingProducts()
        {
            return Ok(await _service.GetBestSellingProductsAsync());
        }

        [HttpGet("{productId}/images")]
        public async Task<IActionResult> Images(int productId)
        {
            return Ok(await _service.GetProductImagesAsync(productId));
        }

        [HttpGet("{productId}/attributes")]
        public async Task<IActionResult> Attributes(int productId)
        {
            return Ok(await _service.GetProductAttributesAsync(productId));
        }

        [HttpGet("{productId}/reviews")]
        public async Task<IActionResult> Reviews(int productId)
        {
            return Ok(await _service.GetProductReviewsAsync(productId));
        }

        [HttpGet("{productId}/related")]
        public async Task<IActionResult> RelatedProducts(int productId)
        {
            return Ok(await _service.GetRelatedProductsAsync(productId));
        }
    }
}
