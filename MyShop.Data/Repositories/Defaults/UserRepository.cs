using Microsoft.AspNetCore.Identity;
using MyShop.Data.Context;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories.Defaults
{
    public class UserRepository :IUserRepository
    {

        private readonly ShopContext _db;
        private readonly SignInManager<ShopUser> _signInManager;
        private readonly UserManager<ShopUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(ShopContext db,
            UserManager<ShopUser> userManager,
            SignInManager<ShopUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;

        }

        public async Task<IdentityResult> AddUserAsync(ShopUser value, string password)
        {
            return await _userManager.CreateAsync(value, password);         
        }

        public async Task<IdentityResult> AddToRoleAsync(ShopUser value, string role)
        {
            IdentityResult result;

            if( await _roleManager.RoleExistsAsync(role))
            {
               result = await _userManager.AddToRoleAsync(value,role);
            }
            else
            {
                throw new ArgumentException($"{role} as Role doesnt exist");
            }

            return result;
        }

        public async Task<SignInResult> SignInAsync(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, false, false);
        }

        public async Task<IEnumerable<string>> GetUserRoles(ShopUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ShopUser> GetUserByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

    }
}
