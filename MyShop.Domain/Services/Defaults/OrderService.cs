using AutoMapper;
using MyShop.Data.Models;
using MyShop.Data.Repositories;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services.Defaults
{
   public  class OrderService : IOrderService
    {
        private readonly IShopCartItemRepository _items;
        private readonly IOrderRepository _orders;
        private readonly IMapper _mapper;
        private readonly IUserRepository _users;
        private readonly IDiscountService _discount;

        public OrderService(IOrderRepository orders, 
            IShopCartItemRepository items, 
            IMapper mapper, 
            IUserRepository users,
            IDiscountService discount)
        {
            _orders = orders;
            _items = items;
            _mapper = mapper;
            _users = users;
            _discount = discount;
        }

        public async Task CreateOrderAsync(string userName)
        {
            var user = await _users.GetUserByUserName(userName);            

            var allItems = await _items.Find(x=>x.ShopCartId == user.ShopCartId);

            if (allItems.Count() == 0)
            {
                throw new ArgumentNullException("ShopCart does not contain purchases");
            }

            Order newOrder = new Order()
            {
                User = user
            };

            foreach (var it in allItems)
            {
                newOrder.Details.Add(new OrderDetail()
                {
                    ProductId = it.ProductId,
                    TotalCost = it.Product.Price*it.Quantity,
                    Quantity = it.Quantity
                });
            }

            newOrder.TotalCost = allItems.Sum(x=>x.Quantity * x.Product.Price);

            var userRoles = await _users.GetUserRoles(user);

            newOrder.TotalCost *= _discount.CalculateDiscount(userRoles);            

            await  _orders.AddOrderAsync(newOrder);

           await _items.DeleteRangeAsync(allItems);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersForPersonAsync(string userName)
        {
           var orders = await _orders.GetAllOrdersForPersonAsync(userName);

            var orderDTOs = _mapper.Map<IEnumerable<Order>,IEnumerable<OrderDTO>>(orders);

            return orderDTOs;
        }
    }
}
