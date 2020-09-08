using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.SearchFilters
{
    public class ProductFilterDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageCapacity { get; set; } = 10;
    }
}
