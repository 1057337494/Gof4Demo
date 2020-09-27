using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleTemplete
{
    public abstract class ShopTemplete
    {
       public void CustomerBySomething()
        {
            CustomerIn();
            CustomerBuy();
            CustomerOut();
        }

        protected virtual void CustomerIn()
        {
            Console.WriteLine("顾客进入了超市");
        }

        protected virtual void CustomerOut()
        {
            Console.WriteLine("顾客走出了超市");
        }

        protected abstract void CustomerBuy();

    }
}
