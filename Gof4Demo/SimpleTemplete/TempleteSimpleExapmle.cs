using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleTemplete
{
    public class TempleteSimpleExapmle
    {
        public void ShopSell()
        {
            var auto = new AutoShopTemplete();
            auto.CustomerBySomething();

            var super = new SuperShopTemplete();
            super.CustomerBySomething();
        }


    }
}
