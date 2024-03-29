﻿using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ship-power-plant-types")]

    public class ShipPowerPlantTypeController : ControllerBase
    {
        private readonly ShipPowerPlantTypeService _shipPowerPlantTypeService;

        public ShipPowerPlantTypeController(ShipPowerPlantTypeService shipPowerPlantTypeService)
        {
            _shipPowerPlantTypeService = shipPowerPlantTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipPowerPlantTypeDTO>>> GetAllShipPowerPlantTypesAsync()
        {
            var shipPowerPlantTypes = await _shipPowerPlantTypeService.GetShipPowerPlantTypesListAsync();
            return Ok(shipPowerPlantTypes);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ShipPowerPlantTypeDTO>> GetShipPowerPlantTypeByIdAsync([Required] Guid id)
        {
            var shipPowerPlantType = await _shipPowerPlantTypeService.GetShipPowerPlantTypeByIdAsync(id);
            return Ok(shipPowerPlantType);
        }

        [HttpPost]
        public async Task<ActionResult<ShipPowerPlantTypeDTO>> CreateShipPowerPlantTypeAsync([FromBody][Required] CreateShipPowerPlantTypeDTO request)
        {
            var shipPowerPlantType = await _shipPowerPlantTypeService.CreateShipPowerPlantTypeAsync(request);
            return Ok(shipPowerPlantType);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ShipPowerPlantTypeDTO>> UpdateShipPowerPlantTypeAsync(Guid id, [FromBody][Required] UpdateShipPowerPlantTypeDTO request)
        {
            var shipPowerPlantType = await _shipPowerPlantTypeService.UpdateShipPowerPlantTypeAsync(id, request);
            return Ok(shipPowerPlantType);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipPowerPlantTypeAsync([Required] Guid id)
        {
            await _shipPowerPlantTypeService.DeleteShipPowerPlantTypeAsync(id);
            return NoContent();
        }
    }
}
