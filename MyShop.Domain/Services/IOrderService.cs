using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userName);
        Task<IEnumerable<OrderDTO>> GetOrdersForPersonAsync(string userName);
    }
}
