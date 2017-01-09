using Microsoft.VisualStudio.TestTools.UnitTesting;
using Liskov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTest
{
    [TestClass()]
    public class WorldWideShippingStrategyTests
    {
        private WorldWideShippingStrategy _strategy;
        private Size<float> _validDimentions;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) { }

        [TestInitialize]
        public void TestInitialize()
        {
            _validDimentions = new Size<float>() { X = 10f, Y = 10f };
            _strategy = new WorldWideShippingStrategy(100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void WorldWideShippingStrategyTest()
        {
            decimal ret = _strategy.CalculateShippingCost(1f, _validDimentions, null);
            Assert.Equals(ret, decimal.Zero);
        }
    }
}