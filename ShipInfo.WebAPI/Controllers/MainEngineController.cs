using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("main-engines")]

    public class MainEngineController : ControllerBase
    {
        private readonly MainEngineService _mainEngineService;

        public MainEngineController(MainEngineService mainEngineService)
        {
            _mainEngineService = mainEngineService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMainEnginesAsync()
        {
            var mainEngines = await _mainEngineService.GetMainEnginesListAsync();
            return Ok(mainEngines);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetMainEngineByIdAsync([Required] Guid id)
        {
            var mainEngine = await _mainEngineService.GetMainEngineByIdAsync(id);
            return Ok(mainEngine);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMainEngineAsync([FromBody][Required] CreateMainEngineDTO request)
        {
            var mainEngine = await _mainEngineService.CreateMainEngineAsync(request);
            return Ok(mainEngine);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateMainEngineAsync(Guid id, [FromBody][Required] UpdateMainEngineDTO request)
        {
            var mainEngine = await _mainEngineService.UpdateMainEngineAsync(id, request);
            return Ok(mainEngine);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteMainEngineAsync([Required] Guid id)
        {
            await _mainEngineService.DeleteMainEngineAsync(id);
            return NoContent();
        }
    }
}
