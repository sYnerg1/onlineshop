
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Data.Context;
using MyShop.Data.Repositories;
using MyShop.Data.Repositories.Defaults;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data
{
    public static class DependencyLoader
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
