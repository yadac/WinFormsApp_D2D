using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample;

namespace SampleTest
{
    [TestClass]
    public class UnitTest1
    {
        UserModel model;

        public TestContext TestContext { get; set; }

        [ClassInitialize]

        [TestInitialize]
        public void TestInitialize()
        {
            model = new UserModel();
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

        // Parameterized Tests. show below.
        // https://www.rhyous.com/2015/05/08/row-tests-or-paramerterized-tests-mstest-csv/
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        [DeploymentItem(@"Data\Data.csv")]
        public void TestMethod3()
        {
            model.AddUser(new User()
            {
                Name = TestContext.DataRow[0].ToString(),
                Age = Int32.Parse(TestContext.DataRow[1].ToString()),
            });

            Assert.AreEqual(model.users.Count, 1);
        }


        [Ignore]
        [TestMethod]
        public void ValidateTest()
        {
            Assert.Fail();
        }

    }
}
