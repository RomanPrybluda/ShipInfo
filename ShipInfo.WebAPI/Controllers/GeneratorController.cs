using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("generator")]

    public class GeneratorController : ControllerBase
    {
        private readonly GeneratorService _generatorService;

        public GeneratorController(GeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGenerators()
        {
            var generators = await _generatorService.GetGeneratorsListAsync();
            return Ok(generators);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetGeneratorById([Required] Guid id)
        {
            var generator = await _generatorService.GetGeneratorByIdAsync(id);
            return Ok(generator);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGenerator([FromBody][Required] CreateGeneratorDTO request)
        {
            var generator = await _generatorService.CreateGeneratorAsync(request);
            return Ok(generator);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateGenerator(Guid id, [FromBody][Required] UpdateGeneratorDTO request)
        {
            var generator = await _generatorService.UpdateGeneratorAsync(id, request);
            return Ok(generator);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteGenerator([Required] Guid id)
        {
            await _generatorService.DeleteGeneratorAsync(id);
            return NoContent();
        }
    }
}
