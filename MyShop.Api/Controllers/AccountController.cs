using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Domain.Services;

namespace MyShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _users;
        RoleManager<IdentityRole> _roles;

        public AccountController( IUserService users, RoleManager<IdentityRole> roles)
        {
            _users = users;
            _roles = roles;
        }

        /// <summary>
        /// Register new User.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     api\Registration
        ///       {
        ///        "username" : "testlogin"
        ///        "password": "Testpass",
        ///        }
        /// </remarks>
        /// <response code="201">User registered</response> 
        /// <response code="400">Bad request</response> 
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(ShopUserDTO model)
        {

            ShopUserDTO user = new ShopUserDTO()
            {
                UserName = model.UserName,
                Password = model.Password
            };

            try
            {
                var createResult = await _users.CreateUser(user);

                if(!createResult.Succeeded)
                {
                    return BadRequest();
                }

                var roleResult = await _users.AddToRoleAsyc(user);

                if (!roleResult.Succeeded)
                {
                    return BadRequest();
                }
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Login and get JWT.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     api\Login
        ///       {
        ///        "username" : "testlogin"
        ///        "password": "Testpassword",
        ///        }
        /// </remarks>
        /// <response code="200">New istance of JWT</response> 
        /// <response code="400">Invalid login or password</response> 
        [HttpPost("Login")]
        public async Task<object> Login(ShopUserDTO model)
        {
            try
            {
               var result = await _users.SignIn(model);

                if (result.Succeeded)
                {

                    var jwtToken = await  _users.GetJWT(model.UserName);

                    return Ok(jwtToken);
                }

                return BadRequest(result.ToString());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }   
        }
    }
}
