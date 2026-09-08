using Marketplacesellerportal.Interface;
using Microsoft.AspNetCore.Mvc;

using MarketplaceOrderEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrder;

namespace Marketplacesellerportal.MarketplaceOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketplaceOrderController : ControllerBase
    {
        private readonly IMarketplaceOrderService _service;

        public MarketplaceOrderController(
            IMarketplaceOrderService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL ORDERS
        // GET: api/MarketplaceOrder
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _service.GetAllAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An error occurred while retrieving marketplace orders.",
                        error = ex.Message,
                        innerException = ex.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // GET ORDER BY ID
        // GET: api/MarketplaceOrder/1
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _service.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound(new
                    {
                        message = "Marketplace order not found.",
                        marketplaceOrderId = id
                    });
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An error occurred while retrieving the marketplace order.",
                        error = ex.Message,
                        innerException = ex.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // GET ORDERS BY SELLER
        // GET: api/MarketplaceOrder/seller/6
        // =========================================================

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySellerId(int sellerId)
        {
            try
            {
                var orders =
                    await _service.GetBySellerIdAsync(sellerId);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An error occurred while retrieving seller marketplace orders.",
                        error = ex.Message,
                        innerException = ex.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // GET ORDERS BY CUSTOMER
        // GET: api/MarketplaceOrder/customer/3
        // =========================================================

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            try
            {
                var orders =
                    await _service.GetByCustomerIdAsync(customerId);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An error occurred while retrieving customer marketplace orders.",
                        error = ex.Message,
                        innerException = ex.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // GET ORDER BY ORDER NUMBER
        // GET: api/MarketplaceOrder/number/AMZ-ORD-001
        // =========================================================

        [HttpGet("number/{marketplaceOrderNumber}")]
        public async Task<IActionResult> GetByOrderNumber(
            string marketplaceOrderNumber)
        {
            if (string.IsNullOrWhiteSpace(marketplaceOrderNumber))
            {
                return BadRequest(new
                {
                    message = "Marketplace order number is required."
                });
            }

            try
            {
                var order =
                    await _service.GetByOrderNumberAsync(
                        marketplaceOrderNumber);

                if (order == null)
                {
                    return NotFound(new
                    {
                        message = "Marketplace order not found.",
                        marketplaceOrderNumber
                    });
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An error occurred while retrieving the marketplace order.",
                        error = ex.Message,
                        innerException = ex.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // CREATE ORDER
        // POST: api/MarketplaceOrder
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] MarketplaceOrderEntity order)
        {
            if (order == null)
            {
                return BadRequest(new
                {
                    message = "Marketplace order data is required."
                });
            }

            try
            {
                var createdOrder =
                    await _service.CreateAsync(order);

                return StatusCode(
                    StatusCodes.Status201Created,
                    new
                    {
                        message = "Marketplace order created successfully.",

                        marketplaceOrderId =
                            createdOrder.MarketplaceOrderId,

                        marketplaceOrderNumber =
                            createdOrder.MarketplaceOrderNumber,

                        sellerId =
                            createdOrder.SellerId,

                        customerId =
                            createdOrder.CustomerId,

                        marketplaceAccountId =
                            createdOrder.MarketplaceAccountId,

                        orderStatus =
                            createdOrder.OrderStatus,

                        totalAmount =
                            createdOrder.TotalAmount,

                        itemCount =
                            createdOrder.Items?.Count ?? 0
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "An error occurred while creating the marketplace order.",

                        error =
                            ex.Message,

                        innerException =
                            ex.InnerException?.Message,

                        innerInnerException =
                            ex.InnerException?.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // UPDATE ORDER
        // PUT: api/MarketplaceOrder/1
        // =========================================================

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] MarketplaceOrderEntity order)
        {
            if (order == null)
            {
                return BadRequest(new
                {
                    message = "Marketplace order data is required."
                });
            }

            if (id != order.MarketplaceOrderId)
            {
                return BadRequest(new
                {
                    message =
                        "The route ID does not match MarketplaceOrderId."
                });
            }

            try
            {
                var updatedOrder =
                    await _service.UpdateAsync(order);

                if (updatedOrder == null)
                {
                    return NotFound(new
                    {
                        message =
                            "Marketplace order not found.",

                        marketplaceOrderId = id
                    });
                }

                // IMPORTANT:
                // Do not directly serialize the EF entity graph.
                return Ok(new
                {
                    message =
                        "Marketplace order updated successfully.",

                    marketplaceOrderId =
                        updatedOrder.MarketplaceOrderId,

                    marketplaceOrderNumber =
                        updatedOrder.MarketplaceOrderNumber,

                    sellerId =
                        updatedOrder.SellerId,

                    customerId =
                        updatedOrder.CustomerId,

                    marketplaceAccountId =
                        updatedOrder.MarketplaceAccountId,

                    orderStatus =
                        updatedOrder.OrderStatus,

                    totalAmount =
                        updatedOrder.TotalAmount,

                    itemCount =
                        updatedOrder.Items?.Count ?? 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "An error occurred while updating the marketplace order.",

                        error =
                            ex.Message,

                        innerException =
                            ex.InnerException?.Message,

                        innerInnerException =
                            ex.InnerException?.InnerException?.Message
                    });
            }
        }

        // =========================================================
        // DELETE ORDER
        // DELETE: api/MarketplaceOrder/1
        // =========================================================

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted =
                    await _service.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound(new
                    {
                        message =
                            "Marketplace order not found.",

                        marketplaceOrderId = id
                    });
                }

                return Ok(new
                {
                    message =
                        "Marketplace order deleted successfully.",

                    marketplaceOrderId = id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message =
                            "An error occurred while deleting the marketplace order.",

                        error =
                            ex.Message,

                        innerException =
                            ex.InnerException?.Message,

                        innerInnerException =
                            ex.InnerException?.InnerException?.Message
                    });
            }
        }
    }
}