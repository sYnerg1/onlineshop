using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Context
{
    public static class SeedUsersAndRoles
    {
        public static async Task SeedAdminUser(ShopContext context, IServiceProvider services)
        {
            var roleMannger =  services.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = {"Admin","User","GoldUser" };

            IdentityResult result;

            foreach(var role in roles)
            {
               if(!(await  roleMannger.RoleExistsAsync(role)))
                {
                   result = await roleMannger.CreateAsync(new IdentityRole(role));
                }
            }

            var userManager = services.GetRequiredService<UserManager<ShopUser>>();

            ShopUser admin = new ShopUser()
            {
                 UserName="admin"
            };

            result =  await userManager.CreateAsync(admin, "adminpass");

            result = await userManager.AddToRoleAsync(admin, "Admin");

            ShopUser goldUser = new ShopUser()
            {
                UserName = "Bob"
            };

            result = await userManager.CreateAsync(goldUser, "goldpass");

            result = await userManager.AddToRoleAsync(goldUser, "GoldUser");

            await  context.SaveChangesAsync();
;        }
    }
}
