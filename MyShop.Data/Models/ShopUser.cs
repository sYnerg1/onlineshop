using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class ShopUser :IdentityUser
    {
        public List<Order> Order { get; set; }
        public ShopCart ShopCart { get; set; }
    }
}
