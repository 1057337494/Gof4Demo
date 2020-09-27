using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gof4Demo.SimpleBuilder.Tests
{
    [TestClass()]
    public class SimpleExampleTests
    {
        [TestMethod]
        public void GetTriangleTest()
        {
            new SimpleBuildExample().GetTriangle();
        }
    }
}