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
        public async Task<ActionResult> GetAllOwners()
        {
            var owners = await _ownerService.GetOwnersListAsync();
            return Ok(owners);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetOwnerById([Required] Guid id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOwner([FromBody][Required] CreateOwnerDTO request)
        {
            var owner = await _ownerService.CreateOwnerAsync(request);
            return Ok(owner);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateOwner(Guid id, [FromBody][Required] UpdateOwnerDTO request)
        {
            var owner = await _ownerService.UpdateOwnerAsync(id, request);
            return Ok(owner);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteOwner([Required] Guid id)
        {
            await _ownerService.DeleteOwnerAsync(id);
            return NoContent();
        }
    }
}
