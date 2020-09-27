using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gof4Demo.SimpleTemplete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gof4Demo.SimpleTemplete.Tests
{
    [TestClass()]
    public class TempleteSimpleExapmleTests
    {
        [TestMethod()]
        public void ShopSellTest()
        {
            new TempleteSimpleExapmle().ShopSell();
        }
    }
}