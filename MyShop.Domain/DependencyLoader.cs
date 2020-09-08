using Microsoft.Extensions.DependencyInjection;
using MyShop.Domain.Services;
using MyShop.Domain.Services.Defaults;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain
{
   public static class DependencyLoader
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            Data.DependencyLoader.Load(services);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopCartService, ShopCartService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
