using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleTemplete
{
    public class SuperShopTemplete : ShopTemplete
    {


        protected override void CustomerBuy()
        {
            Console.WriteLine("顾客在导购员的指引下购买商品");
        }

        protected override void CustomerIn()
        {
            Console.WriteLine("顾客搭乘电梯进入超市");
        }

        protected override void CustomerOut()
        {
            Console.WriteLine("顾客搭乘电梯离开超市");
        }
    }
}
