using Microsoft.EntityFrameworkCore;
using MyShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories.Defaults
{
    public class ShopCartRepository :IShopCartRepository
    {
        private readonly ShopContext _db;

        public ShopCartRepository(ShopContext db)
        {
            _db = db;
        }


        public async Task ClearShopCartAsync(int shopCartId)
        {
            var existShopcart = await _db.ShopCarts.FirstOrDefaultAsync(x=>x.Id==shopCartId);

            if(existShopcart!=null)
            {

            }
        }
    }
}
