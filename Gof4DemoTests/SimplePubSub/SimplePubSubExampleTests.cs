using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gof4Demo.SimplePubSub;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gof4Demo.SimplePubSub.Tests
{
    [TestClass()]
    public class SimplePubSubExampleTests
    {
        [TestMethod()]
        public void CreateOrderTest()
        {
            var bll = new SimplePubSubExample();

            bll.CreateOrder();
            bll.CreateAccount();
        }
    }
}