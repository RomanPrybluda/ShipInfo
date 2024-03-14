using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("shipbuilders")]

    public class ShipbuilderController : ControllerBase
    {
        private readonly ShipbuilderService _shipbuilderService;

        public ShipbuilderController(ShipbuilderService shipbuilderService)
        {
            _shipbuilderService = shipbuilderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipbuilderDTO>>> GetAllShipbuilders()
        {
            var shipbuilders = await _shipbuilderService.GetShipbuildersListAsync();
            return Ok(shipbuilders);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShipbuilderDTO>> GetShipbuilderById([Required] Guid id)
        {
            var shipbuilder = await _shipbuilderService.GetShipbuilderByIdAsync(id);
            return Ok(shipbuilder);
        }

        [HttpPost]
        public async Task<ActionResult<ShipbuilderDTO>> CreateShipbuilder([FromBody][Required] CreateShipbuilderDTO request)
        {
            var shipbuilder = await _shipbuilderService.CreateShipbuilderAsync(request);
            return Ok(shipbuilder);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ShipbuilderDTO>> UpdateShipbuilder(Guid id, [FromBody][Required] UpdateShipbuilderDTO request)
        {
            var shipbuilder = await _shipbuilderService.UpdateShipbuilderAsync(id, request);
            return Ok(shipbuilder);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipbuilder([Required] Guid id)
        {
            await _shipbuilderService.DeleteShipbuilderAsync(id);
            return NoContent();
        }
    }
}
