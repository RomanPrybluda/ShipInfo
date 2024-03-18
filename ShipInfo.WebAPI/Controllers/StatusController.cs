using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("statuses")]

    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;

        public StatusController(StatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStatusesAsync()
        {
            var statuses = await _statusService.GetStatusesListAsync();
            return Ok(statuses);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetStatusByIdAsync([Required] Guid id)
        {
            var status = await _statusService.GetStatusByIdAsync(id);
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStatusAsync([FromBody][Required] CreateStatusDTO request)
        {
            var status = await _statusService.CreateStatusAsync(request);
            return Ok(status);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateStatusAsync([Required] Guid id, [FromBody] UpdateStatusDTO request)
        {
            var status = await _statusService.UpdateStatusAsync(id, request);
            return Ok(status);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteStatusAsync([Required] Guid id)
        {
            await _statusService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}