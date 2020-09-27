using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimpleProxy
{
    public interface IUser
    {
        public string Name { get; }
        public void BuyTick();



    }
}
