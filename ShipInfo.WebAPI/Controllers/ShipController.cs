using Microsoft.AspNetCore.Mvc;
using ShipInfo.Domain;
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

        //[HttpGet]
        //public async Task<ActionResult> GetAllShipsAsyncAsync()
        //{
        //    var ships = await _shipService.GetShipsListAsync();
        //    return Ok(ships);
        //}

        [HttpGet("imoNumber")]
        public async Task<ActionResult> GetShipsByIMONumberAsync([Required] int imoNumber)
        {
            var ship = await _shipService.GetShipsByIMONumberAsync(imoNumber);
            return Ok(ship);
        }

        [HttpGet("shipName")]
        public async Task<ActionResult> GetShipByNameAsync([Required] string shipName)
        {
            var ship = await _shipService.GetShipsByNameAsync(shipName);
            return Ok(ship);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetShipByIdAsyncAsync([Required] Guid id)
        {
            var ship = await _shipService.GetShipByIdAsync(id);
            return Ok(ship);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateShipAsyncAsync([Required][FromBody] CreateShipDTO request)
        //{
        //    var ship = await _shipService.CreateShipAsync(request);
        //    return Ok(ship);
        //}

        //[HttpPut("{id:Guid}")]
        //public async Task<ActionResult> UpdateShipAsyncAsync([Required] Guid id, [FromBody] UpdateShipDTO request)
        //{
        //    var ship = await _shipService.UpdateShipAsync(id, request);
        //    return Ok(ship);
        //}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteShipAsync([Required] Guid id)
        {
            await _shipService.DeleteShipAsync(id);
            return NoContent();
        }
    }
}