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
        public static async Task SeedRoles(ShopContext context, IServiceProvider services)
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

            await  context.SaveChangesAsync();
;        }

        public static async Task SeedAdmin(ShopContext context, IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ShopUser>>();

            if (userManager.FindByNameAsync("admin") == null)
            {
                ShopUser admin = new ShopUser()
                {
                    UserName = "admin"
                };

                await userManager.CreateAsync(admin, "adminpass");

                await userManager.AddToRoleAsync(admin, "Admin");
                await context.SaveChangesAsync();
            }
        }
    }
}
