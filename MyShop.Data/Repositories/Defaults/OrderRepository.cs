using Microsoft.EntityFrameworkCore;
using MyShop.Data.Context;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories.Defaults
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopContext _db;
        private readonly IShopCartItemRepository _cartItems;
        private readonly IUserRepository _users;

        public OrderRepository(ShopContext db)
        {
            _db = db;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForPersonAsync(string userName)
        {
            var result =  await _db.Orders
                .Include(x => x.User)
                .Include(x=>x.Details)
                .Where(x => x.User.UserName == userName)
                .ToListAsync();

            return result;
        }
    }
}
