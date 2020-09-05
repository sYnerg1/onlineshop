using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain
{
   public  static class DependencyLoader
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            Data.DependencyLoader.Load(services);
            services.
        }
    }
}
