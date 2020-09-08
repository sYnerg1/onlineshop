﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Models
{
    public class OrderDetail
    {
       public int Id { get; set; }

       public Product Product { get; set; }
       public int ProductId { get; set; }

       public Order Order { get; set; }
       public int OrderId { get; set; }

       public int Quantity { get; set; }

       public decimal TotalCost { get; set; }
    }
}
