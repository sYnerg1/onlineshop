﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
