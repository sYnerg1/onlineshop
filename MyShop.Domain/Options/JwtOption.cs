using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Options
{
    public class JwtOption
    {
        public string Key { get; set; }

        public int Expires { get; set; }
    }
}
