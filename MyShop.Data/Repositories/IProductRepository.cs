using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        IQueryable GetQuery();
    }
}
