using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
   public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersForPersonAsync(string userName);
    }
}
