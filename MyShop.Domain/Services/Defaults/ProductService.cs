using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Services.Defaults
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

    }
}
