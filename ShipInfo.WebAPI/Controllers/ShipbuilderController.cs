using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ship-builders")]

    public class ShipBuilderController : ControllerBase
    {
        private readonly ShipBuilderService _shipBuilderService;

        public ShipBuilderController(ShipBuilderService shipbuilderService)
        {
            _shipBuilderService = shipbuilderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipBuilderDTO>>> GetAllShipbuildersAsync()
        {
            var shipbuilders = await _shipBuilderService.GetShipBuildersListAsync();
            return Ok(shipbuilders);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShipBuilderDTO>> GetShipbuilderByIdAsync([Required] Guid id)
        {
            var shipbuilder = await _shipBuilderService.GetShipBuilderByIdAsync(id);
            return Ok(shipbuilder);
        }

        [HttpPost]
        public async Task<ActionResult<ShipBuilderDTO>> CreateShipbuilderAsync([FromBody][Required] CreateShipBuilderDTO request)
        {
            var shipbuilder = await _shipBuilderService.CreateShipBuilderAsync(request);
            return Ok(shipbuilder);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ShipBuilderDTO>> UpdateShipbuilderAsync(Guid id, [FromBody][Required] UpdateShipBuilderDTO request)
        {
            var shipbuilder = await _shipBuilderService.UpdateShipBuilderAsync(id, request);
            return Ok(shipbuilder);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipbuilderAsync([Required] Guid id)
        {
            await _shipBuilderService.DeleteShipBuilderAsync(id);
            return NoContent();
        }
    }
}
