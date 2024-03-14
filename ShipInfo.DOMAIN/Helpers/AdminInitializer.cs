using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ShipInfo.DAL;

namespace Domain.Helpers
{
    public class AdminInitializer
    {

        public static async Task InitializeRole(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            string adminEmail = "admin@weather.com";
            string adminPassword = "AdminWeather!23";
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
