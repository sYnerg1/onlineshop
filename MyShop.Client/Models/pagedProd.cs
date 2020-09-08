using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Client.Models
{
    public class pagedProd
    {
        public IEnumerable<Product> Products { get; set; }
        public int PageNumber { get; set; }
    }
}
