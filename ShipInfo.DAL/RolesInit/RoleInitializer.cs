namespace ShipInfo.Domain
{
    public class RoleInitializer
    {

        public static async Task InitializeRole(RoleManager roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.ADMIN))
            {
                await roleManager.CreateAsync(
                    new IdentityRole
                    {
                        Name = Roles.ADMIN
                    }
                );
            }

            if (!await roleManager.RoleExistsAsync(Roles.SHIP_ADMIN))
            {
                await roleManager.CreateAsync(
                    new IdentityRole()
                    {
                        Name = Roles.SHIP_ADMIN
                    }
                );
            }

            if (!await roleManager.RoleExistsAsync(Roles.USER))
            {
                await roleManager.CreateAsync(
                    new IdentityRole()
                    {
                        Name = Roles.USER
                    }
                );
            }

        }
    }
}
