using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleProxy
{
    public class UserProxy : IUser
    {
        private IUser _user;

        public UserProxy(IUser user)
        {
            _user = user;
        }

        public string Name => throw new NotImplementedException();

        public void  BuyTick()
        {
            Console.WriteLine("代理查询票数");

            _user.BuyTick();

            Console.WriteLine("代理结束查询");
        }
    }
}
