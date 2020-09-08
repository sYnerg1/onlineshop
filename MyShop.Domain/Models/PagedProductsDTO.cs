using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class PagedProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public int PageNumber { get; set; }
    }
}
