using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("auxiliary-engine-manufacturers")]

    public class AuxiliaryEngineManufacturerController : ControllerBase
    {
        private readonly AuxiliaryEngineManufacturerService _auxiliaryEngineManufacturerService;

        public AuxiliaryEngineManufacturerController(AuxiliaryEngineManufacturerService auxiliaryEngineManufacturerService)
        {
            _auxiliaryEngineManufacturerService = auxiliaryEngineManufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuxiliaryEngineManufacturersAsync()
        {
            var auxiliaryEngineManufacturers = await _auxiliaryEngineManufacturerService.GetAuxiliaryEngineManufacturersListAsync();
            return Ok(auxiliaryEngineManufacturers);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetAuxiliaryEngineManufacturerByIdAsync([Required] Guid id)
        {
            var auxiliaryEngineManufacturer = await _auxiliaryEngineManufacturerService.GetAuxiliaryEngineManufacturerByIdAsync(id);
            return Ok(auxiliaryEngineManufacturer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuxiliaryEngineManufacturerAsync([FromBody][Required] CreateAuxiliaryEngineManufacturerDTO request)
        {
            var auxiliaryEngineManufacturer = await _auxiliaryEngineManufacturerService.CreateAuxiliaryEngineManufacturerAsync(request);
            return Ok(auxiliaryEngineManufacturer);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAuxiliaryEngineManufacturerAsync(Guid id, [FromBody][Required] UpdateAuxiliaryEngineManufacturerDTO request)
        {
            var auxiliaryEngineManufacturer = await _auxiliaryEngineManufacturerService.UpdateAuxiliaryEngineManufacturerAsync(id, request);
            return Ok(auxiliaryEngineManufacturer);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAuxiliaryEngineManufacturerAsync([Required] Guid id)
        {
            await _auxiliaryEngineManufacturerService.DeleteAuxiliaryEngineManufacturerAsync(id);
            return NoContent();
        }
    }
}
