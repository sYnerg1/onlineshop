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
    }
}
