using MyShop.Data.Models;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
    public interface IShopCartService
    {
        Task<bool> AddToCartAsync(int productId, int shopCartId);
        Task<ShopCartDTO> GetShopCartForUserAsync(int shopCartId);
        Task DeleteCartItemAsync(int itemId);
    }
}
