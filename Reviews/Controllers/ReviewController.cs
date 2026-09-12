using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Reviews.Interfaces;

namespace Marketplacesellerportal.Reviews.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL
        // GET /api/reviews
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _service.GetAllAsync();

            return Ok(reviews);
        }

        // =========================================================
        // GET FILTER / SEARCH / SORT / PAGINATION
        // GET /api/reviews/filter
        // =========================================================

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredReviews(
            [FromQuery] string? search,
            [FromQuery] int? rating,
            [FromQuery] string? status,
            [FromQuery] string? sort,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // Pagination
            if (page.HasValue || limit.HasValue)
            {
                var currentPage = page ?? 1;
                var currentLimit = limit ?? 10;

                if (currentPage < 1)
                    currentPage = 1;

                if (currentLimit < 1)
                    currentLimit = 10;

                if (currentLimit > 100)
                    currentLimit = 100;

                var result = await _service.GetPagedAsync(
                    currentPage,
                    currentLimit);

                var totalPages = result.TotalCount == 0
                    ? 0
                    : (int)Math.Ceiling(
                        result.TotalCount / (double)currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    totalPages,
                    items = result.Items
                });
            }

            // Search / Rating / Status
            if (!string.IsNullOrWhiteSpace(search) ||
                rating.HasValue ||
                !string.IsNullOrWhiteSpace(status))
            {
                var result = await _service.SearchAsync(
                    search,
                    rating,
                    status);

                return Ok(result);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result = await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            return Ok(await _service.GetAllAsync());
        }

        // =========================================================
        // STATISTICS
        // GET /api/reviews/stats
        // =========================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =========================================================
        // GET BY ID
        // GET /api/reviews/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Review not found."
                });
            }

            return Ok(result);
        }

        // =========================================================
        // GET BY SELLER
        // GET /api/reviews/seller/6
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            var result = await _service.GetBySellerIdAsync(sellerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY CUSTOMER
        // GET /api/reviews/customer/3
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _service.GetByCustomerIdAsync(customerId);

            return Ok(result);
        }

        // =========================================================
        // GET BY PRODUCT
        // GET /api/reviews/product/6
        // =========================================================

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var result = await _service.GetByProductIdAsync(productId);

            return Ok(result);
        }

        // =========================================================
        // GET BY RATING
        // GET /api/reviews/rating/5
        // =========================================================

        [HttpGet("rating/{rating:int}")]
        public async Task<IActionResult> GetByRating(int rating)
        {
            var result = await _service.GetByRatingAsync(rating);

            return Ok(result);
        }

        // =========================================================
        // GET BY STATUS
        // GET /api/reviews/status/Approved
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // POST /api/reviews
        // =========================================================

        // =========================================================
        // REJECT REVIEW
        // PUT /api/reviews/6/reject
        // =========================================================

        [HttpPut("{id:int}/reject")]
        public async Task<IActionResult> Reject(int id)
        {
            try
            {
                var review = await _service.GetByIdAsync(id);

                if (review == null)
                {
                    return NotFound(new
                    {
                        message = $"Review with ID {id} not found."
                    });
                }

                review.Status = "Rejected";

                var result = await _service.UpdateAsync(id, review);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Failed to reject review.",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value != null && x.Value.Errors.Count > 0)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value!.Errors
                            .Select(e => e.ErrorMessage)
                            .ToList()
                    );

                return BadRequest(new
                {
                    message = "Review validation failed.",
                    errors = errors
                });
            }

            if (review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest(new
                {
                    message = "Rating must be between 1 and 5."
                });
            }

            review.ReviewId = 0;

            if (string.IsNullOrWhiteSpace(review.Status))
            {
                review.Status = "Pending";
            }

            if (review.HelpfulCount < 0)
            {
                review.HelpfulCount = 0;
            }

            if (!review.CreatedDate.HasValue)
            {
                review.CreatedDate = DateTime.UtcNow;
            }

            try
            {
                var result = await _service.CreateAsync(review);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = result.ReviewId },
                    result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Failed to create review.",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message
                });
            }
        }
        // =========================================================
        // UPDATE
        // PUT /api/reviews/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest(new
                {
                    message = "Rating must be between 1 and 5."
                });
            }

            if (review.HelpfulCount < 0)
            {
                review.HelpfulCount = 0;
            }

            var result = await _service.UpdateAsync(id, review);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Review not found."
                });
            }

            return Ok(new
            {
                message = "Review updated successfully."
            });
        }

        // =========================================================
        // DELETE
        // DELETE /api/reviews/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Review not found."
                });
            }

            return Ok(new
            {
                message = "Review deleted successfully."
            });
        }
    }
}