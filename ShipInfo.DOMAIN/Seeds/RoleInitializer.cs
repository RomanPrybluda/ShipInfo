﻿using DAL.Models;
using DAL.Models.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using ShipInfo.DAL;

namespace Domain.Seeds
{
    public class RoleInitializer
    {

        public static async Task InitializeRole(RoleManager<IdentityRole> roleManager)
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
