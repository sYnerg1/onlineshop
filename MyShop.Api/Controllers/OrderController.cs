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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
        {
            _orders = orders;
        }

        [HttpPost("")]
        public async Task<ActionResult> Post()
        {
            try
            {
                var currentUserName = User.Identity.Name;

                await _orders.CreateOrderAsync(currentUserName);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
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

                var orderDTOs = await _orders.GetOrdersForPersonAsync(currentUserName);

                return Ok(orderDTOs);
            }           
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.Message);
            }
        }
    }
}
