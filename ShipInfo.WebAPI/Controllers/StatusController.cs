using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("status")]

    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;

        public StatusController(StatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStatuses()
        {
            var statuses = await _statusService.GetStatusesListAsync();
            return Ok(statuses);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetStatusById([Required] Guid id)
        {
            var status = await _statusService.GetStatusByIdAsync(id);
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStatus([FromBody][Required] CreateStatusDTO request)
        {
            var status = await _statusService.CreateStatusAsync(request);
            return Ok(status);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateStatus(Guid id, [FromBody][Required] UpdateStatusDTO request)
        {
            var status = await _statusService.UpdateStatusAsync(id, request);
            return Ok(status);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteStatus([Required] Guid id)
        {
            await _statusService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}