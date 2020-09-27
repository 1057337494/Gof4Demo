using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleProxy
{
    [Intercept(typeof(UserInterceptor))]
    public class User : IUser
    {
        public string Name => "张三";

    
        public void BuyTick()
        {
            Console.WriteLine($"{Name}购买一张车票");
        }
    }
}
