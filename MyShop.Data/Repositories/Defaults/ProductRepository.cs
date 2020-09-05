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
    public class ProductRepository :IProductRepository
    {
        private readonly ShopContext _db;

        public ProductRepository(ShopContext db)
        {
            _db = db;
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public IQueryable GetQuery()
        {
            return _db.Products.AsQueryable();
        }
    }
}
