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

        public UserRepository(ShopContext db,
            UserManager<ShopUser> userManager,
            SignInManager<ShopUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;

        }

        public async Task<IdentityResult> AddUserAsync(ShopUser value, string password)
        {
            return await _userManager.CreateAsync(value, password);
        }

        public async Task<SignInResult> SignInAsync(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, false, false);
        }

        public async Task<ShopUser> GetUserByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }
    }
}
