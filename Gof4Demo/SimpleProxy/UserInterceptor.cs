using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleProxy
{
    public class UserInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("代理查询票数");

            invocation.Proceed();

            Console.WriteLine("代理结束查询");
        }
    }
}
