using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShipInfo.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShipInfo.DOMAIN
{
    public class JWTService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public JWTService(UserManager<AppUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> GenerateToken(string userId, string email)
        {

            var claim = new List<Claim>();
            claim.Add(new Claim("sub", userId));
            claim.Add(new Claim("email", userId));

            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claim.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWTparams:Key"]));

            var token = new JwtSecurityToken(
                _config["JWTparams:Issuer"],
                _config["JWTparams:Audience"],
                expires: DateTime.Now.AddDays(24),
                claims: claim,
                signingCredentials: new SigningCredentials(
                    authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);

        }

    }
}
