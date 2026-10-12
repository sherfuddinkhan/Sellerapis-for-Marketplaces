using Marketplacesellerportal.FacilityChannel.DTOs;
using Marketplacesellerportal.FacilityChannel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.FacilityChannel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacilityChannelController(
IFacilityChannelService service) : ControllerBase
{
    // GET: api/FacilityChannel/all
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetAllAsync();
        return Ok(result);
    }
// GET: api/FacilityChannel/5/10
[HttpGet("{sellerId:int}/{customerId:int}")]
    public async Task<IActionResult> Get(
    int sellerId,
    int customerId)
    {
        var result = await service.GetAsync(sellerId, customerId);
        return Ok(result);
    }

    // GET: api/FacilityChannel/filter?sellerId=5&customerId=10
    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter(
        [FromQuery] FacilityChannelInventoryFilterRequest filter)
    {
        var result = await service.GetByFilterAsync(filter);
        return Ok(result);
    }

    // GET: api/FacilityChannel/details/1
    [HttpGet("details/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await service.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound(new
            {
                message = $"Facility channel inventory record {id} was not found."
            });
        }

        return Ok(result);
    }

    // POST: api/FacilityChannel
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateFacilityChannelInventoryRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await service.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    // PUT: api/FacilityChannel/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateFacilityChannelInventoryRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await service.UpdateAsync(id, request);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new
            {
                message = $"Facility channel inventory record {id} was not found."
            });
        }
    }

    // DELETE: api/FacilityChannel/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = $"Facility channel inventory record {id} was not found."
            });
        }

        return Ok(new
        {
            message = "Facility channel inventory record deleted successfully.",
            id
        });
    }

}
