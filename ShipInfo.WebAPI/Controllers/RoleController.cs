using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("roles")]

    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoleByIdAsync([Required] Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoleAsync([FromBody][Required] string roleName)
        {
            var role = await _roleService.CreateRoleAsync(roleName);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoleAsync(Guid id, [FromBody][Required] string roleName)
        {
            var role = await _roleService.UpdateRoleAsync(id, roleName);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoleAsync([Required] Guid id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }

}