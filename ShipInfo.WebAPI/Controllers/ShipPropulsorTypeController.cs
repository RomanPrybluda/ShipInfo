using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ship-propulsor-types")]

    public class ShipPropulsorTypeController : ControllerBase
    {
        private readonly ShipPropulsorTypeService _shipPropulsorTypeService;

        public ShipPropulsorTypeController(ShipPropulsorTypeService shipPropulsorTypeService)
        {
            _shipPropulsorTypeService = shipPropulsorTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipPropulsorTypeDTO>>> GetAllShipPropulsorTypesAsync()
        {
            var shipPropulsorTypes = await _shipPropulsorTypeService.GetShipPropulsorTypesListAsync();
            return Ok(shipPropulsorTypes);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShipPropulsorTypeDTO>> GetShipPropulsorTypeByIdAsync([Required] Guid id)
        {
            var shipPropulsorType = await _shipPropulsorTypeService.GetShipPropulsorTypeByIdAsync(id);
            return Ok(shipPropulsorType);
        }

        [HttpPost]
        public async Task<ActionResult<ShipPropulsorTypeDTO>> CreateShipPropulsorTypeAsync([FromBody][Required] CreateShipPropulsorTypeDTO request)
        {
            var shipPropulsorType = await _shipPropulsorTypeService.CreateShipPropulsorTypeAsync(request);
            return Ok(shipPropulsorType);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ShipPropulsorTypeDTO>> UpdateShipPropulsorTypeAsync(Guid id, [FromBody][Required] UpdateShipPropulsorTypeDTO request)
        {
            var shipPropulsorType = await _shipPropulsorTypeService.UpdateShipPropulsorTypeAsync(id, request);
            return Ok(shipPropulsorType);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipPropulsorTypeAsync([Required] Guid id)
        {
            await _shipPropulsorTypeService.DeleteShipPropulsorTypeAsync(id);
            return NoContent();
        }
    }
}
