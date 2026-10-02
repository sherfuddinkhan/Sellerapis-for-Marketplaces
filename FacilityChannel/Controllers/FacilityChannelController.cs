using Marketplacesellerportal.FacilityChannel.DTOs;
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.FacilityChannel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacilityChannelController(IFacilityChannelService service) : ControllerBase
{
    [HttpGet("{sellerId}/{customerId}")]
    public async Task<IActionResult> Get(int sellerId, int customerId)
    {
        var result = await service.GetAsync(sellerId, customerId);
        return Ok(result);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery] FacilityChannelInventoryFilterRequest filter)
    {
        var result = await service.GetByFilterAsync(filter);
        return Ok(result);
    }
}