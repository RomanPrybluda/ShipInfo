using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("auxiliary-engines")]

    public class AuxiliaryEngineController : ControllerBase
    {
        private readonly AuxiliaryEngineService _auxiliaryEngineService;

        public AuxiliaryEngineController(AuxiliaryEngineService auxiliaryEngineService)
        {
            _auxiliaryEngineService = auxiliaryEngineService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuxiliaryEngines()
        {
            var auxiliaryEngines = await _auxiliaryEngineService.GetAuxiliaryEnginesListAsync();
            return Ok(auxiliaryEngines);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetAuxiliaryEngineById([Required] Guid id)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.GetAuxiliaryEngineByIdAsync(id);
            return Ok(auxiliaryEngine);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuxiliaryEngine([FromBody][Required] CreateAuxiliaryEngineDTO request)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.CreateAuxiliaryEngineAsync(request);
            return Ok(auxiliaryEngine);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAuxiliaryEngine(Guid id, [FromBody][Required] UpdateAuxiliaryEngineDTO request)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.UpdateAuxiliaryEngineAsync(id, request);
            return Ok(auxiliaryEngine);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAuxiliaryEngine([Required] Guid id)
        {
            await _auxiliaryEngineService.DeleteAuxiliaryEngineAsync(id);
            return NoContent();
        }
    }
}
