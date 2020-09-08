using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Data.Models;
using MyShop.Data.Repositories;
using MyShop.Domain.Models;
using MyShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services.Defaults
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _users;

        private readonly IOptions<JwtOption> _jwtOptions;

        public UserService(IUserRepository users, IOptions<JwtOption> jwtOptions)
        {
            _users = users;
            _jwtOptions = jwtOptions;
        }

        public async Task<IdentityResult> CreateUser(ShopUserDTO user)
        {

            ShopUser syncaUser = new ShopUser()
            {
                UserName = user.UserName,
            };

            if (await _users.GetUserByUserName(user.UserName) == null)
            {
                return await _users.AddUserAsync(syncaUser, user.Password);
            }
            else
            {
                throw new Exception("User already exist");
            }

        }

        public async Task<SignInResult> SignIn(ShopUserDTO user)
        {

            return await _users.SignInAsync(user.UserName, user.Password);
        }

        public async Task<ShopUserDTO> FindUserByName(string userName)
        {
            var syncaUser = await _users.GetUserByUserName(userName);

            return new ShopUserDTO() { UserName = syncaUser.UserName };
        }

        public async Task<object> GetJWT(string userName)
        {
            ShopUser user = await _users.GetUserByUserName(userName);

            if(user!=null)
            {
                var tokenTimeCreated = DateTime.UtcNow;

                var userRoles = await _users.GetUserRoles(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("ShopCartId", user.ShopCartId.ToString())
                };

                foreach (string role in userRoles)
                {
                  claims.Add(new Claim(ClaimTypes.Role, role));
                }

                string secretKey = _jwtOptions.Value.Key;
                int expires = _jwtOptions.Value.Expires;

                var jwt = new JwtSecurityToken(
                        issuer: "Me",
                        audience: "My Api",
                        notBefore: tokenTimeCreated,
                        claims: claims,
                        expires: tokenTimeCreated.AddMinutes(expires),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(secretKey)),
                            SecurityAlgorithms.HmacSha256));

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return encodedJwt;
            }
            else
            {
                throw new ArgumentNullException();
            }
           
        }

        public async Task<IdentityResult> AddToRoleAsyc(ShopUserDTO user, string role="User")
        {          
           var existUser = await _users.GetUserByUserName(user.UserName);

            IdentityResult result;

            if (existUser != null)
            {
                return result = await _users.AddToRoleAsync(existUser, role);
            }
            else
            {
                throw new ArgumentNullException();
            }           
        }
    }
}
