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
                int shopCartId = int.Parse(User.Claims.FirstOrDefault(x=>x.Type=="ShopCartId").Value);

                var result = await _shopCart.AddToCartAsync(id, shopCartId);

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
                int shopCartId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "ShopCartId").Value);

                var result = await _shopCart.GetShopCartForUserAsync(shopCartId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
    }
}
