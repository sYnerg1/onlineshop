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

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public IQueryable<Product> GetQuery()
        {
            return _db.Products.AsQueryable();
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
