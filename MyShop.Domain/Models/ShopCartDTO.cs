using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class ShopCartDTO
    {
        public IEnumerable<ShopCartItemDTO> ItemDTOs { get; set; }
        public decimal TotalCost { get; set; }
    }
}
