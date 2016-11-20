using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample;

namespace SampleTest
{
    [TestClass]
    public class UnitTest1
    {
        User user;

        [TestInitialize]
        public void TestInitialize()
        {
            user = new User() { Name = "adachi", Age = 34 };
        }

        [TestMethod, TestCategory("smoke")]
        public void TestMethod1()
        {
            int exp = 10;
            int act = 5 + 5;
            Assert.AreEqual(exp, act);
        }

        [Ignore]
        [TestMethod]
        public void TestMethod2()
        {
            int exp = 10;
            int act = 2 * 3;
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            user.AddAge(10);
            Assert.AreEqual(user.Age, 44);
        }

        [Ignore]
        [TestMethod]
        public void ValidateTest()
        {
            Assert.Fail();
        }
    }
}
