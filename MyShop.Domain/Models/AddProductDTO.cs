using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class AddProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IFormFile Photo { get; set; }
    }
}
