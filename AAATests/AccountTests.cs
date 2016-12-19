using Microsoft.VisualStudio.TestTools.UnitTesting;
using AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTest
{
    /// <summary>
    /// AAA
    /// Arrange
    /// Act
    /// Assert
    /// </summary>
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void AddingTransactionChangesBalance()
        {
            // Arrange
            var account = new Account();
     
            // Act
            account.AddTransaction(200m);
            
            // Assert       
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        public void AccountsHaveAnOpeningBalanceOfZero()
        {
            // Arrange

            // Act
            var account = new Account();

            // Assert
            Assert.AreEqual(0m, account.Balance);
        }
    }
}