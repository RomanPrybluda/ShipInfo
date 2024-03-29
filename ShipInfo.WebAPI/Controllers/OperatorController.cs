﻿using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("operators")]

    public class OperatorController : ControllerBase
    {
        private readonly OperatorService _operatorService;

        public OperatorController(OperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOperatorsAsync()
        {
            var operators = await _operatorService.GetOperatorsListAsync();
            return Ok(operators);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetOperatorByIdAsync([Required] Guid id)
        {
            var @operator = await _operatorService.GetOperatorByIdAsync(id);
            return Ok(@operator);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOperatorAsync([FromBody][Required] CreateOperatorDTO request)
        {
            var @operator = await _operatorService.CreateOperatorAsync(request);
            return Ok(@operator);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateOperatorAsync(Guid id, [FromBody][Required] UpdateOperatorDTO request)
        {
            var @operator = await _operatorService.UpdateOperatorAsync(id, request);
            return Ok(@operator);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteOperatorAsync([Required] Guid id)
        {
            await _operatorService.DeleteOperatorAsync(id);
            return NoContent();
        }
    }
}
