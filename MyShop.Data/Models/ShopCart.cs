﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Data.Models
{
    public class ShopCart
    {
        public int Id { get; set; }

        public ShopUser User { get; set; }

        public List<ShopCartItem> Items { get; set; }

        public ShopCart()
        {
            Items = new List<ShopCartItem>();
        }

        public decimal TotalCost { get; set; }
    }
}
