﻿using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("ship-types")]

    public class ShipTypeController : ControllerBase
    {
        private readonly ShipTypeService _shipTypeService;

        public ShipTypeController(ShipTypeService shipTypeService)
        {
            _shipTypeService = shipTypeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllShipTypesAsync()
        {
            var shipTypes = await _shipTypeService.GetShipTypesListAsync();
            return Ok(shipTypes);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetShipTypeByIdAsync([Required] Guid id)
        {
            var shipType = await _shipTypeService.GetShipTypeByIdAsync(id);
            return Ok(shipType);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShipTypeAsync([FromBody][Required] CreateShipTypeDTO request)
        {
            var shipType = await _shipTypeService.CreateShipTypeAsync(request);
            return Ok(shipType);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateShipTypeAsync(Guid id, [FromBody][Required] UpdateShipTypeDTO request)
        {
            var shipType = await _shipTypeService.UpdateShipTypeAsync(id, request);
            return Ok(shipType);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteShipTypeAsync([Required] Guid id)
        {
            await _shipTypeService.DeleteShipTypeAsync(id);
            return NoContent();
        }
    }
}