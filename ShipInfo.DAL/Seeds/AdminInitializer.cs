using Microsoft.Extensions.Configuration;
using ShipInfo.Domain.Entities;

namespace ShipInfo.Domain
{
    public class AdminInitializer
    {

        public static async Task InitializeRole(AppUser userManager, IConfiguration configuration)
        {

            var adminEmail = configuration["AdminSettings:Email"];
            var adminPassword = configuration["AdminSettings:Password"];

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "Admin",
                };

                var result = await userManager.CreateAsync(admin, adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception();
                }

                result = await userManager.AddToRoleAsync(admin, Roles.ADMIN);

                if (!result.Succeeded)
                {
                    throw new Exception();
                }

            }

        }
    }
}
