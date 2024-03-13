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
        public async Task<ActionResult> GetAllShips()
        {
            var ships = await _shipService.GetShipsListAsync();
            return Ok(ships);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetShipById([Required] Guid id)
        {
            var ship = await _shipService.GetShipByIdAsync(id);
            return Ok(ship);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShip([FromBody] CreateShipDTO request)
        {
            var ship = await _shipService.CreateShipAsync(request);
            return Ok(ship);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateShip([FromBody] ShipByIdDTO request)
        {
            var ship = await _shipService.UpdateShipAsync(request);
            return Ok(ship);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteShip([Required] Guid id)
        {
            await _shipService.DeleteShipAsync(id);
            return NoContent();
        }
    }
}