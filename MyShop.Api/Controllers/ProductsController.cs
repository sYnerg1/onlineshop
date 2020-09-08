using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Domain.SearchFilters;
using MyShop.Domain.Services;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _products;
        private readonly IMapper _mapper;

        public ProductsController(IProductService products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get([FromQuery] ProductFilterDTO filter)
        {
            try
            {
                var pagedListOfProducts = await _products.Find(filter);

                return Ok(pagedListOfProducts);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Add new product.
        /// </summary>
        /// <response code="201">Product added</response> 
        /// <response code="400">If image is null</response> 
        /// <response code="401">If JWT isn't correct</response> 
        /// <response code="500">Data base error</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("")]
        public async Task<ActionResult> Post([FromForm]AddProductDTO productdto)
        {
            try
            {
                await _products.AddAsync(productdto);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddProductDTO product)
        {
            if(id!=product.Id)
            {
                return BadRequest("Id doesn't match");
            }

            try
            {
                 await _products.UpdateAsync(id, product);

                 return Ok(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
