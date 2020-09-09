using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(IEnumerable<string> roles);
    }
}
