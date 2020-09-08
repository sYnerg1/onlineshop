using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class ShopCartItemDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int ShopCartId { get; set; }
    }
}
