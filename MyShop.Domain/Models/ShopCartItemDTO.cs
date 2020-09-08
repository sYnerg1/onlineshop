using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class ShopCartItemDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
