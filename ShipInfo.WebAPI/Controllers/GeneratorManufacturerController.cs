using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("generator-manufacturers")]

    public class GeneratorManufacturerController : ControllerBase
    {
        private readonly GeneratorManufacturerService _generatorManufacturerService;

        public GeneratorManufacturerController(GeneratorManufacturerService generatorManufacturerService)
        {
            _generatorManufacturerService = generatorManufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGeneratorManufacturersAsync()
        {
            var generatorManufacturers = await _generatorManufacturerService.GetGeneratorManufacturersListAsync();
            return Ok(generatorManufacturers);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetGeneratorManufacturerByIdAsync([Required] Guid id)
        {
            var generatorManufacturer = await _generatorManufacturerService.GetGeneratorManufacturerByIdAsync(id);
            return Ok(generatorManufacturer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGeneratorManufacturerAsync([FromBody][Required] CreateGeneratorManufacturerDTO request)
        {
            var generatorManufacturer = await _generatorManufacturerService.CreateGeneratorManufacturerAsync(request);
            return Ok(generatorManufacturer);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateGeneratorManufacturerAsync(Guid id, [FromBody][Required] UpdateGeneratorManufacturerDTO request)
        {
            var generatorManufacturer = await _generatorManufacturerService.UpdateGeneratorManufacturerAsync(id, request);
            return Ok(generatorManufacturer);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteGeneratorManufacturerAsync([Required] Guid id)
        {
            await _generatorManufacturerService.DeleteGeneratorManufacturerAsync(id);
            return NoContent();
        }
    }
}