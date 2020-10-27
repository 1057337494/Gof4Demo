using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Gof4Demo.SimpeChainOfResponsibility.ChainOfResponsibilityExample.Tests
{
    [TestClass()]
    public class FilterStringTests
    {
        [TestMethod()]
        public void FilterStringTest()
        {
            new FilterString().Filter();
        }

        [TestMethod()]
        public void FilterTest()
        {
            Assert.Fail();
        }
    }
}