using Marketplacesellerportal.ExportJobs.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplacesellerportal.ExportJobs.Controllers
{
    [ApiController]
    [Route("api/export-jobs")]
    public class ExportJobsController : ControllerBase
    {
        private readonly IExportJobService _service;

        public ExportJobsController(IExportJobService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExportJob dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.ExportJobId },
                result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] ExportJob dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Export job updated successfully"
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Export job deleted successfully"
            });
        }
    }
}