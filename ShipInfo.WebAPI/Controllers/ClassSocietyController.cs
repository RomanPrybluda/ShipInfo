using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("class-societies")]

    public class ClassSocietyController : ControllerBase
    {
        private readonly ClassSocietyService _classSocietyService;

        public ClassSocietyController(ClassSocietyService classSocietyService)
        {
            _classSocietyService = classSocietyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClassSocietiesAsync()
        {
            var classSocieties = await _classSocietyService.GetClassSocietiesListAsync();
            return Ok(classSocieties);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetClassSocietyByIdAsync([Required] Guid id)
        {
            var classSociety = await _classSocietyService.GetClassSocietyByIdAsync(id);
            return Ok(classSociety);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClassSocietyAsync([FromBody] CreateClassSocietyDTO request)
        {
            var classSociety = await _classSocietyService.CreateClassSocietyAsync(request);
            return Ok(classSociety);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateClassSocietyAsync(Guid id, [FromBody] UpdateClassSocietyDTO request)
        {
            var classSociety = await _classSocietyService.UpdateClassSocietyAsync(id, request);
            return Ok(classSociety);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteClassSocietyAsync([Required] Guid id)
        {
            await _classSocietyService.DeleteClassSocietyAsync(id);
            return NoContent();
        }
    }
}
