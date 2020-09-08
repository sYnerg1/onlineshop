using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Services;

namespace MyShop.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShopCartController : ControllerBase
    {
        private readonly IShopCartService _shopCart;

        public ShopCartController(IShopCartService shopCart)
        {
            _shopCart = shopCart;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Post(int id)
        {
            try
            {
                var currentUserName = User.Identity.Name;

                var result = await _shopCart.AddToCartAsync(id, currentUserName);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }    
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var currentUserName = User.Identity.Name;

                var result = await _shopCart.GetAllItemsDTOForUserAsync(currentUserName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
    }
}
