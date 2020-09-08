using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
   public  class OrderDTO
    {
        public int Id { get; set; }

        public decimal TotalCost { get; set; }

        public bool IsPaid { get; set; }

        public List<OrderDetailDTO> Details { get; set; }

        public OrderDTO()
        {
            Details = new List<OrderDetailDTO>();
        }

    }
}
