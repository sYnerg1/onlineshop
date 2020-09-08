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
        private readonly IShopCartService _shopcart;
        private readonly IOrderRepository _orders;
        private readonly IMapper _mapper;
        private readonly IUserRepository _users;

        public OrderService(IOrderRepository orders, IShopCartService shopcart, IMapper mapper, IUserRepository users)
        {
            _orders = orders;
            _shopcart = shopcart;
            _mapper = mapper;
            _users = users;
        }

        public async Task CreateOrderAsync(string userName)
        {
            var user = await _users.GetUserByUserName(userName);
                      
            var allItems =  await _shopcart.GetAllItemsForUserAsync(userName);

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
                    Quantity = it.Quantity
                });
            }

            newOrder.TotalCost = allItems.Sum(x=>x.Quantity * x.Product.Price);

           await  _orders.AddOrderAsync(newOrder);

           await _shopcart.DeleteCartItemsAsync(allItems);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersForPersonAsync(string userName)
        {
           var orders = await _orders.GetAllOrdersForPersonAsync(userName);

            var orderDTOs = _mapper.Map<IEnumerable<Order>,IEnumerable<OrderDTO>>(orders);

            return orderDTOs;
        }
    }
}
