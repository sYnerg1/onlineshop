using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public AccountController( IUserService users)
        {
            _users = users;
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
                var result = await _users.CreateUser(user);
                return StatusCode(201, result.ToString());
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
            ShopUserDTO dto = new ShopUserDTO()
            {
                UserName = model.UserName,
                Password = model.Password
            };

            try
            {
                var result = await _users.SignIn(dto);

                if (result.Succeeded)
                {
                    var user = await _users.FindUserByName(dto.UserName);

                    var jwtToken = await  _users.GetJWT(user);

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
