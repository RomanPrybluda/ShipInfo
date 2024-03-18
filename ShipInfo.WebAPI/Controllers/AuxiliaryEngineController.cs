using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
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
        public async Task<ActionResult> GetAllAuxiliaryEnginesAsync()
        {
            var auxiliaryEngines = await _auxiliaryEngineService.GetAuxiliaryEnginesListAsync();
            return Ok(auxiliaryEngines);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetAuxiliaryEngineByIdAsync([Required] Guid id)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.GetAuxiliaryEngineByIdAsync(id);
            return Ok(auxiliaryEngine);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuxiliaryEngineAsync([FromBody][Required] CreateAuxiliaryEngineDTO request)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.CreateAuxiliaryEngineAsync(request);
            return Ok(auxiliaryEngine);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAuxiliaryEngineAsync(Guid id, [FromBody][Required] UpdateAuxiliaryEngineDTO request)
        {
            var auxiliaryEngine = await _auxiliaryEngineService.UpdateAuxiliaryEngineAsync(id, request);
            return Ok(auxiliaryEngine);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAuxiliaryEngineAsync([Required] Guid id)
        {
            await _auxiliaryEngineService.DeleteAuxiliaryEngineAsync(id);
            return NoContent();
        }
    }
}
