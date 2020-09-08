using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class ShopCart
    {
        public int Id { get; set; }

        public List<ShopCartItem> Items;

        public ShopUser User { get; set; }

        public ShopCart()
        {
            Items = new List<ShopCartItem>();
        }
 
    }
}
