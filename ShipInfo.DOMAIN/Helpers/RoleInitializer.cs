using DAL.Models;
using DAL.Models.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class RoleInitializer
    {
        
        public static async Task InitializeRole(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RoleNames.Admin))
            { 
                await roleManager.CreateAsync(
                    new IdentityRole
                    {
                        Name = RoleNames.Admin
                    }
                );
            }

            if (!await roleManager.RoleExistsAsync(RoleNames.Standart))
            {
                await roleManager.CreateAsync(
                    new IdentityRole()
                    {
                        Name = RoleNames.Standart
                    }
                );
            }

        }
    }
}
