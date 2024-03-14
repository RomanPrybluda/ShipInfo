using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetAllGeneratorManufacturers()
        {
            var generatorManufacturers = await _generatorManufacturerService.GetGeneratorManufacturersListAsync();
            return Ok(generatorManufacturers);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetGeneratorManufacturerById([Required] Guid id)
        {
            var generatorManufacturer = await _generatorManufacturerService.GetGeneratorManufacturerByIdAsync(id);
            return Ok(generatorManufacturer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGeneratorManufacturer([FromBody][Required] CreateGeneratorManufacturerDTO request)
        {
            var generatorManufacturer = await _generatorManufacturerService.CreateGeneratorManufacturerAsync(request);
            return Ok(generatorManufacturer);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateGeneratorManufacturer(Guid id, [FromBody][Required] UpdateGeneratorManufacturerDTO request)
        {
            var generatorManufacturer = await _generatorManufacturerService.UpdateGeneratorManufacturerAsync(id, request);
            return Ok(generatorManufacturer);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteGeneratorManufacturer([Required] Guid id)
        {
            await _generatorManufacturerService.DeleteGeneratorManufacturerAsync(id);
            return NoContent();
        }
    }
}