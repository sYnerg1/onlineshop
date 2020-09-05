using Microsoft.AspNetCore.Identity;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(ShopUser value, string password);
        Task<ShopUser> GetUserByUserName(string userName);
        Task<SignInResult> SignInAsync(string userName, string password);
    }
}
