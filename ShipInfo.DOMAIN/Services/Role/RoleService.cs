using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShipInfo.DOMAIN
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetRoleByIdAsync(Guid id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityRole> CreateRoleAsync(string roleName)
        {
            var roleExisted = await _roleManager.FindByNameAsync(roleName);

            if (roleExisted != null)
                throw new CustomException(CustomExceptionType.RoleAlreadyExists, $"Role {roleName} already exists.");

            var createdRole = new IdentityRole(roleName);

            await _roleManager.CreateAsync(createdRole);

            var role = await _roleManager.FindByNameAsync(roleName);

            return role;
        }

        public async Task<IdentityRole> UpdateRoleAsync(Guid id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Role found with ID {id}");

            role.Name = roleName;

            await _roleManager.UpdateAsync(role);

            var updatedRole = await _roleManager.FindByNameAsync(roleName);

            return updatedRole;
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Role found with ID {id}");

            await _roleManager.DeleteAsync(role);

        }
    }
}
