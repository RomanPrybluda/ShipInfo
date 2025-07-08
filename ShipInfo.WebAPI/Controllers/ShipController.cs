using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ships")]

    public class ShipController : ControllerBase
    {
        private readonly ShipService _shipService;

        public ShipController(ShipService shipService)
        {
            _shipService = shipService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllShipsAsync()
        {
            var ships = await _shipService.GetShipsListAsync();
            return Ok(ships);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetShipByIdAsync([Required] Guid id)
        {
            var ship = await _shipService.GetShipByIdAsync(id);
            return Ok(ship);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShipAsync([Required][FromBody] CreateShipDTO request)
        {
            var ship = await _shipService.CreateShipAsync(request);
            return Ok(ship);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateShipAsync([Required] Guid id, [FromBody] UpdateShipDTO request)
        {
            var ship = await _shipService.UpdateShipAsync(id, request);
            return Ok(ship);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteShipAsync([Required] Guid id)
        {
            await _shipService.DeleteShipAsync(id);
            return NoContent();
        }
    }
}