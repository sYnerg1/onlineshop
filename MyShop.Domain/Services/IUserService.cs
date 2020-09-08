using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
   public  interface IUserService
    {
        Task<IdentityResult> CreateUser(ShopUserDTO user);
        Task<IdentityResult> AddToRoleAsyc(ShopUserDTO user,string role="User");
        Task<SignInResult> SignIn(ShopUserDTO user);
        Task<ShopUserDTO> FindUserByName(string userName);
        Task<object> GetJWT(string userName);
    }
}
