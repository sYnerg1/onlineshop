using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Services.Defaults
{
    public class DiscountService : IDiscountService
    {
        private const decimal _goldUserDiscount = 0.07M;
        private decimal totaldiscount =0;
        private int discountApply = 0;

        public decimal CalculateDiscount(IEnumerable<string> roles)
        {
            if(roles.Contains("GoldUser"))
            {
                totaldiscount += _goldUserDiscount;
                discountApply++;
            }

            return  1 - totaldiscount/discountApply;
        }
    }
}
