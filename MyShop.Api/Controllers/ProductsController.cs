using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Services;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _products;

        public ProductsController(IProductService products)
        {
            _products =  products;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            return Ok("Hello");
        }
    }
}
