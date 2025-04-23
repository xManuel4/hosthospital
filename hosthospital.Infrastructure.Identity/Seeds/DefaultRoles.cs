﻿using hosthospital.Core.Application.Enum;
using Microsoft.AspNetCore.Identity;


namespace hosthospital.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {

        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
