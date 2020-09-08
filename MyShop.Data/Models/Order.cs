using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class Order
    {
       public int Id { get; set; }

        public decimal TotalCost { get; set; }

        public bool IsPaid { get; set; }

        public List<OrderDetail> Details { get; set; }

        public ShopUser User { get; set; }
        public string UserId { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }
    }
}
