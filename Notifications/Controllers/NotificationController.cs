using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Notifications.Interfaces;

namespace Marketplacesellerportal.Notifications.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notification = await _service.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
            => Ok(await _service.GetByCustomerAsync(customerId));

        [HttpGet("customer/{customerId}/unread")]
        public async Task<IActionResult> GetUnread(int customerId)
            => Ok(await _service.GetUnreadAsync(customerId));

        [HttpPost]
        public async Task<IActionResult> Create(Notification notification)
            => Ok(await _service.CreateAsync(notification));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Notification notification)
        {
            if (!await _service.UpdateAsync(id, notification))
                return NotFound();

            return Ok();
        }

        [HttpPut("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            if (!await _service.MarkAsReadAsync(id))
                return NotFound();

            return Ok();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(
    [FromQuery] string search)
        {
            return Ok(await _service.SearchAsync(search));
        }

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(
            [FromQuery] string? sort)
        {
            return Ok(await _service.GetSortedAsync(sort));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 15)
        {
            return Ok(
                await _service.GetPagedAsync(page, limit));
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            return Ok(
                await _service.GetStatisticsAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
