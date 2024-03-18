using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("owners")]

    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _ownerService;

        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOwnersAsync()
        {
            var owners = await _ownerService.GetOwnersListAsync();
            return Ok(owners);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetOwnerByIdAsync([Required] Guid id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOwnerAsync([FromBody][Required] CreateOwnerDTO request)
        {
            var owner = await _ownerService.CreateOwnerAsync(request);
            return Ok(owner);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateOwnerAsync(Guid id, [FromBody][Required] UpdateOwnerDTO request)
        {
            var owner = await _ownerService.UpdateOwnerAsync(id, request);
            return Ok(owner);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteOwnerAsync([Required] Guid id)
        {
            await _ownerService.DeleteOwnerAsync(id);
            return NoContent();
        }
    }
}
