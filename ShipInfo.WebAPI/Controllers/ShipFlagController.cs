using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ship-flags")]

    public class ShipFlagController : ControllerBase
    {
        private readonly ShipFlagService _shipFlagService;

        public ShipFlagController(ShipFlagService shipFlagService)
        {
            _shipFlagService = shipFlagService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllShipFlags()
        {
            var shipFlags = await _shipFlagService.GetShipFlagsListAsync();
            return Ok(shipFlags);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetShipFlagById([Required] Guid id)
        {
            var shipFlag = await _shipFlagService.GetShipFlagByIdAsync(id);
            return Ok(shipFlag);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShipFlag([FromBody][Required] CreateShipFlagDTO request)
        {
            var shipFlag = await _shipFlagService.CreateShipFlagAsync(request);
            return Ok(shipFlag);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateShipFlag(Guid id, [FromBody][Required] UpdateShipFlagDTO request)
        {
            var shipFlag = await _shipFlagService.UpdateShipFlagAsync(id, request);
            return Ok(shipFlag);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipFlag([Required] Guid id)
        {
            await _shipFlagService.DeleteShipFlagAsync(id);
            return NoContent();
        }
    }
}
