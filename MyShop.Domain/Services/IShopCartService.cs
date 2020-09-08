﻿using MyShop.Data.Models;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
    public interface IShopCartService
    {
        Task<bool> AddToCartAsync(int productId, string userName);
        Task<IEnumerable<ShopCartItemDTO>> GetAllItemsDTOForUserAsync(string userName);
        Task<IEnumerable<ShopCartItem>> GetAllItemsForUserAsync(string userName);
        Task<bool> DeleteCartItemsAsync(IEnumerable<ShopCartItem> shopCartItems);
    }
}
