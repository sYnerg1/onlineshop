using Microsoft.EntityFrameworkCore;
using MyShop.Data.Context;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories.Defaults
{
    public class ShopCartItemRepository : IShopCartItemRepository
    {
        private readonly ShopContext _db;

        public ShopCartItemRepository(ShopContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(ShopCartItem item)
        {
            await _db.ShopCartItems.AddAsync(item);

            return await _db.SaveChangesAsync() > 0;
        }

        public async  Task<ShopCartItem> FindOne(Expression<Func<ShopCartItem, bool>> predicate)
        {
            var result = await _db.ShopCartItems.FirstOrDefaultAsync(predicate);

            return result;
        }

        public async Task<IEnumerable<ShopCartItem>> GetAll(int cartId)
        {
           return await _db.ShopCartItems
                .Include(x=>x.Product)
                .Where(x=>x.ShopCartId==cartId)
                .ToListAsync();
        }

        public async  Task<bool> UpdateAsync(ShopCartItem item)
        {
            bool result = false;

            if(await _db.ShopCartItems.AnyAsync(x => x.Id == item.Id))
            {
                _db.Entry(item).State = EntityState.Modified;
                result = await _db.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<ShopCartItem> items)
        {        
                _db.ShopCartItems.RemoveRange(items);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ShopCartItem>> Find(Expression<Func<ShopCartItem, bool>> predicate)
        {
            var result = await _db.ShopCartItems
                .Where(predicate)
                .ToListAsync();

            return result;
        }
    }
}
