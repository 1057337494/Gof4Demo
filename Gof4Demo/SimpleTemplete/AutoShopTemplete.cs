using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleTemplete
{
    public class AutoShopTemplete : ShopTemplete
    {
        protected override void CustomerBuy()
        {
            Console.WriteLine("顾客自助购买商品");
        }
    }
}
