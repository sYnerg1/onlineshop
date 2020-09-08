using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public ShopCart ShopCart { get; set; }
        public int ShopCartId { get; set; }
    }
}
