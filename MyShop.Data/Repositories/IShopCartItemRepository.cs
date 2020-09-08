using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IShopCartItemRepository
    {
        Task<ShopCartItem> FindOne(Expression<Func<ShopCartItem, Boolean>> predicate);
        Task<bool> AddAsync(ShopCartItem item);
        Task<bool> UpdateAsync(ShopCartItem item);
        Task<IEnumerable<ShopCartItem>> GetAll(int cartId);
        Task<bool> DeleteRangeAsync(IEnumerable<ShopCartItem> items);
        Task<bool> DeleteAsync(ShopCartItem item);
        Task<IEnumerable<ShopCartItem>> Find(Expression<Func<ShopCartItem, bool>> predicate);
    }
}
