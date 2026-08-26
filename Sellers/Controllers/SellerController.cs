using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;
using Marketplacesellerportal.Sellers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.Sellers.Controllers
{
    [ApiController]
    [Route("api/sellers")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _service;

        public SellerController(ISellerService service)
        {
            _service = service;
        }

        // =====================================================
        // GET ALL / SEARCH / FILTER / SORT / PAGINATION
        //
        // GET:
        // /api/sellers
        //
        // SEARCH:
        // /api/sellers?search=john
        //
        // STATUS:
        // /api/sellers?status=active
        //
        // SORT:
        // /api/sellers?sort=seller_name
        //
        // PAGINATION:
        // /api/sellers?page=1&limit=15
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] string? sort,
            [FromQuery] string? status,
            [FromQuery] int? page,
            [FromQuery] int? limit)
        {
            // =====================================================
            // SEARCH
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                var result = await _service.SearchAsync(search);

                return Ok(result);
            }

            // =====================================================
            // STATUS FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(status))
            {
                bool isActive = status.Equals(
                    "active",
                    StringComparison.OrdinalIgnoreCase);

                var result = await _service.GetByStatusAsync(isActive);

                return Ok(result);
            }

            // =====================================================
            // SORT
            // =====================================================

            if (!string.IsNullOrWhiteSpace(sort))
            {
                var result = await _service.GetSortedAsync(sort);

                return Ok(result);
            }

            // =====================================================
            // PAGINATION
            // =====================================================

            if (page.HasValue || limit.HasValue)
            {
                int currentPage = page ?? 1;
                int currentLimit = limit ?? 15;

                var result = await _service.GetPagedAsync(
                    currentPage,
                    currentLimit);

                return Ok(new
                {
                    page = currentPage,
                    limit = currentLimit,
                    totalCount = result.TotalCount,
                    items = result.Items
                });
            }

            // =====================================================
            // GET ALL
            // =====================================================

            return Ok(await _service.GetAllAsync());
        }

        // =====================================================
        // GET SELLER BY ID
        //
        // GET:
        // /api/sellers/1
        // =====================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
            {
                return NotFound(new
                {
                    message = "Seller not found"
                });
            }

            return Ok(seller);
        }

        // =====================================================
        // STATISTICS
        //
        // GET:
        // /api/sellers/stats
        // =====================================================

        [HttpGet("stats")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _service.GetStatisticsAsync();

            return Ok(result);
        }

        // =====================================================
        // CREATE SELLER
        //
        // POST:
        // /api/sellers
        // =====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] RegisterSellerRequest request)
        {
            var seller = new Seller
            {
                // -----------------------------
                // SELLER DETAILS
                // -----------------------------

                SellerName = request.SellerName,
                TradeName = request.TradeName,
                LegalName = request.LegalName,

                // -----------------------------
                // CONTACT DETAILS
                // -----------------------------

                ContactPerson = request.ContactPerson,
                Email = request.Email,
                Phone = request.Phone,

                // -----------------------------
                // TAX DETAILS
                // -----------------------------

                GSTIN = request.GSTIN,

                // -----------------------------
                // ADDRESS DETAILS
                // -----------------------------

                Address = request.Address,
                BuildingName = request.BuildingName,
                Location = request.Location,
                City = request.City,
                State = request.State,
                StateCode = request.StateCode,
                FloorNo = request.FloorNo,
                PostalCode = request.PostalCode,
                Country = request.Country,

                // -----------------------------
                // DEFAULT VALUES
                // -----------------------------

                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _service.CreateAsync(seller);

            return Ok(result);
        }

        // =====================================================
        // UPDATE SELLER
        //
        // PUT:
        // /api/sellers/1
        // =====================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] RegisterSellerRequest request)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
            {
                return NotFound(new
                {
                    message = "Seller not found"
                });
            }

            // -----------------------------
            // SELLER DETAILS
            // -----------------------------

            seller.SellerName = request.SellerName;
            seller.TradeName = request.TradeName;
            seller.LegalName = request.LegalName;

            // -----------------------------
            // CONTACT DETAILS
            // -----------------------------

            seller.ContactPerson = request.ContactPerson;
            seller.Email = request.Email;
            seller.Phone = request.Phone;

            // -----------------------------
            // TAX DETAILS
            // -----------------------------

            seller.GSTIN = request.GSTIN;

            // -----------------------------
            // ADDRESS DETAILS
            // -----------------------------

            seller.Address = request.Address;
            seller.BuildingName = request.BuildingName;
            seller.Location = request.Location;
            seller.City = request.City;
            seller.State = request.State;
            seller.StateCode = request.StateCode;
            seller.FloorNo = request.FloorNo;
            seller.PostalCode = request.PostalCode;
            seller.Country = request.Country;

            seller.UpdatedAt = DateTime.UtcNow;

            await _service.UpdateAsync(seller);

            return Ok(seller);
        }

        // =====================================================
        // DELETE SELLER
        //
        // DELETE:
        // /api/sellers/1
        // =====================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seller = await _service.GetByIdAsync(id);

            if (seller == null)
            {
                return NotFound(new
                {
                    message = "Seller not found"
                });
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}