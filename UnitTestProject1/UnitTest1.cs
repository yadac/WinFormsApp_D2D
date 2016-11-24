using System;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TestData\file01.csv", "file01#csv", DataAccessMethod.Sequential)]
        [DeploymentItem(@"TestData\file01.csv")]
        public void AddTest1()
        {
            int a = (int)this.TestContext.DataRow[0];
            int b = (int)TestContext.DataRow[1];
            int c = (int)TestContext.DataRow[2];
            int actual = a + b;
            int expect = c;
            Trace.WriteLine(string.Format("actual = {0}, expect = {1}", actual, expect));
            Assert.AreEqual(actual, expect);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TestData\file02.csv", "file02#csv", DataAccessMethod.Sequential)]
        [DeploymentItem(@"TestData\file02.csv")]
        public void SubtractTest1()
        {
            int a = (int)this.TestContext.DataRow[0];
            int b = (int)TestContext.DataRow[1];
            int c = (int)TestContext.DataRow[2];
            int actual = a - b;
            int expect = c;
            Trace.WriteLine(string.Format("actual = {0}, expect = {1}", actual, expect));
            Assert.AreEqual(actual, expect);
        }

        [TestMethod]
        public void AddTest2()
        {
            int exp = 10;
            int act = 5 + 5;
            Assert.AreEqual(exp, act);
        }
    }
}
