using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("main-engine-manufacturers")]

    public class MainEngineManufacturerController : ControllerBase
    {
        private readonly MainEngineManufacturerService _mainEngineManufacturerService;

        public MainEngineManufacturerController(MainEngineManufacturerService mainEngineManufacturerService)
        {
            _mainEngineManufacturerService = mainEngineManufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMainEngineManufacturersAsync()
        {
            var mainEngineManufacturers = await _mainEngineManufacturerService.GetMainEngineManufacturersListAsync();
            return Ok(mainEngineManufacturers);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetMainEngineManufacturerByIdAsync([Required] Guid id)
        {
            var mainEngineManufacturer = await _mainEngineManufacturerService.GetMainEngineManufacturerByIdAsync(id);
            return Ok(mainEngineManufacturer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMainEngineManufacturerAsync([FromBody][Required] CreateMainEngineManufacturerDTO request)
        {
            var mainEngineManufacturer = await _mainEngineManufacturerService.CreateMainEngineManufacturerAsync(request);
            return Ok(mainEngineManufacturer);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateMainEngineManufacturerAsync(Guid id, [FromBody][Required] UpdateMainEngineManufacturerDTO request)
        {
            var mainEngineManufacturer = await _mainEngineManufacturerService.UpdateMainEngineManufacturerAsync(id, request);
            return Ok(mainEngineManufacturer);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteMainEngineManufacturerAsync([Required] Guid id)
        {
            await _mainEngineManufacturerService.DeleteMainEngineManufacturerAsync(id);
            return NoContent();
        }
    }
}
