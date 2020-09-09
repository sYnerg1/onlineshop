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

        /// <summary>
        /// Add nproduct to shop cart by id.
        /// </summary>
        /// <response code="201">Product added to shopcart</response> 
        /// <response code="401">If JWT isn't correct</response> 
        /// <response code="500">Data base error</response> 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}")]
        public async Task<ActionResult> Post(int id)
        {
            try
            {
                int shopCartId = int.Parse(User.Claims.FirstOrDefault(x=>x.Type=="ShopCartId").Value);

                var result = await _shopCart.AddToCartAsync(id, shopCartId);

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }    
        }

        /// <summary>
        /// Add nproduct to shop cart by id.
        /// </summary>
        /// <response code="201">Product added to shopcart</response> 
        /// <response code="401">If JWT isn't correct</response> 
        /// <response code="500">Data base error</response> 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Delete shopcart item by id.
        /// </summary>
        /// <response code="201">Item deleted</response> 
        /// <response code="401">If JWT isn't correct</response> 
        /// <response code="500">Data base error</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _shopCart.DeleteCartItemAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
