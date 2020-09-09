using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class ShopUser :IdentityUser
    {
        public List<Order> Orders { get; set; }

        public ShopCart ShopCart { get; set; }

        public int ShopCartId { get; set; }

        public ShopUser()
        {
            Orders = new List<Order>();
         //   ShopCart = new ShopCart();
        }
    }
}
