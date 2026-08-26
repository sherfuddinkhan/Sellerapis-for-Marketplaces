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
        // GET /api/catalog/products?sellerId=6&customerId=3
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
        // GET /api/catalog/products/6?sellerId=6&customerId=3
        // =========================================================

        [HttpGet("products/{id:int}")]
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
            {
                return NotFound(new
                {
                    message = "Product not found."
                });
            }

            return Ok(result);
        }


        // =========================================================
        // SEARCH PRODUCTS
        // POST /api/catalog/search?sellerId=6&customerId=3
        // =========================================================

        [HttpPost("search")]
        public async Task<IActionResult> Search(
            [FromQuery] int sellerId,
            [FromQuery] int customerId,
            [FromBody] ProductSearchRequest request)
        {
            if (request == null)
            {
                return BadRequest(new
                {
                    message = "Search request is required."
                });
            }

            var result = await _service.SearchProductsAsync(
                request,
                sellerId,
                customerId);

            return Ok(result);
        }


        // =========================================================
        // CREATE PRODUCT
        // POST /api/catalog/products
        // =========================================================

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        // GET /api/catalog/brands?sellerId=6&customerId=3
        // =========================================================

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result = await _service.GetBrandsAsync(
                sellerId,
                customerId);

            return Ok(result);
        }


        // =========================================================
        // CATEGORIES
        // GET /api/catalog/categories?sellerId=6&customerId=3
        // =========================================================

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result = await _service.GetCategoriesAsync(
                sellerId,
                customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCTS BY BRAND
        // =========================================================

        [HttpGet("brand/{brandId:int}")]
        public async Task<IActionResult> ProductsByBrand(
            int brandId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductsByBrandAsync(
                    brandId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCTS BY CATEGORY
        // =========================================================

        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> ProductsByCategory(
            int categoryId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductsByCategoryAsync(
                    categoryId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCTS BY PRODUCT TYPE
        // =========================================================

        [HttpGet("producttype/{productTypeId:int}")]
        public async Task<IActionResult> ProductsByProductType(
            int productTypeId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductsByProductTypeAsync(
                    productTypeId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // LATEST PRODUCTS
        // =========================================================

        [HttpGet("latest")]
        public async Task<IActionResult> LatestProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetLatestProductsAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // FEATURED PRODUCTS
        // =========================================================

        [HttpGet("featured")]
        public async Task<IActionResult> FeaturedProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetFeaturedProductsAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // TOP RATED PRODUCTS
        // =========================================================

        [HttpGet("toprated")]
        public async Task<IActionResult> TopRatedProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetTopRatedProductsAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // BEST SELLING PRODUCTS
        // =========================================================

        [HttpGet("bestsellers")]
        public async Task<IActionResult> BestSellingProducts(
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetBestSellingProductsAsync(
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCT IMAGES
        // GET /api/catalog/6/images
        // =========================================================

        [HttpGet("{productId:int}/images")]
        public async Task<IActionResult> Images(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductImagesAsync(
                    productId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCT ATTRIBUTES
        // =========================================================

        [HttpGet("{productId:int}/attributes")]
        public async Task<IActionResult> Attributes(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductAttributesAsync(
                    productId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // PRODUCT REVIEWS
        // =========================================================

        [HttpGet("{productId:int}/reviews")]
        public async Task<IActionResult> Reviews(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetProductReviewsAsync(
                    productId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // RELATED PRODUCTS
        // =========================================================

        [HttpGet("{productId:int}/related")]
        public async Task<IActionResult> RelatedProducts(
            int productId,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.GetRelatedProductsAsync(
                    productId,
                    sellerId,
                    customerId);

            return Ok(result);
        }


        // =========================================================
        // UPDATE PRODUCT
        // PUT /api/catalog/6?sellerId=6&customerId=3
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(
            int id,
            [FromQuery] int sellerId,
            [FromQuery] int customerId,
            [FromBody] UpdateProductRequest request)
        {
            if (request == null)
            {
                return BadRequest(new
                {
                    message = "Request body is required."
                });
            }

            var result =
                await _service.UpdateProductAsync(
                    id,
                    sellerId,
                    customerId,
                    request);

            if (!result)
            {
                return NotFound(new
                {
                    message =
                        "Product not found for the specified seller and customer."
                });
            }

            return Ok(new
            {
                message = "Product updated successfully.",
                productId = id,
                sellerId,
                customerId
            });
        }


        // =========================================================
        // PATCH PRODUCT
        // PATCH /api/catalog/6?sellerId=6&customerId=3
        // =========================================================

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchProduct(
            int id,
            [FromQuery] int sellerId,
            [FromQuery] int customerId,
            [FromBody] UpdateProductRequest request)
        {
            if (request == null)
            {
                return BadRequest(new
                {
                    message = "Request body is required."
                });
            }

            var result =
                await _service.UpdateProductAsync(
                    id,
                    sellerId,
                    customerId,
                    request);

            if (!result)
            {
                return NotFound(new
                {
                    message =
                        "Product not found for the specified seller and customer."
                });
            }

            return Ok(new
            {
                message = "Product updated successfully.",
                productId = id,
                sellerId,
                customerId
            });
        }


        // =========================================================
        // DELETE PRODUCT
        // DELETE /api/catalog/6?sellerId=6&customerId=3
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(
            int id,
            [FromQuery] int sellerId,
            [FromQuery] int customerId)
        {
            var result =
                await _service.DeleteProductAsync(
                    id,
                    sellerId,
                    customerId);

            if (!result)
            {
                return NotFound(new
                {
                    message =
                        "Product not found for the specified seller and customer."
                });
            }

            return Ok(new
            {
                message = "Product deleted successfully.",
                productId = id,
                sellerId,
                customerId
            });
        }
    }
}