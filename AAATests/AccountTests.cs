using Microsoft.VisualStudio.TestTools.UnitTesting;
using AAA;
using AAA.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Moq;

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
        protected static IDisposable Context { get; set; }
        protected static ShimAccount shimAccount;
        protected static StubAccount stubAccount;
        protected static StubIAccountRepository stubRepository;
        protected static AccountService sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            // Setup
            // http://stackoverflow.com/questions/12017711/moles-fakes-how-do-i-implement-a-test-setup
            // todo : what is difference between ClassInitialize and TestInitialize?
            // todo : what is difference between Stub and Shim?
            Context = ShimsContext.Create();
            Console.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
            Context.Dispose();
            Context = null;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("TestInitialize");
            shimAccount = new ShimAccount();
            stubAccount = new StubAccount();
            stubRepository = new StubIAccountRepository();
            sut = new AccountService(stubRepository);
        }

        [TestMethod()]
        public void AddingTransactionChangesBalance()
        {
            // Arrange
            
            // Act
            stubAccount.AddTransaction(200m);
            stubAccount.AddTransaction(400m);

            // Assert       
            Assert.AreEqual(600m, stubAccount.Balance);
        }

        [TestMethod]
        public void AccountsHaveAnOpeningBalanceOfZero()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(0m, stubAccount.Balance);
        }

        [TestMethod]
        public void Adding100TransactionChangesBalance()
        {
            // Arrange

            // Act
            stubAccount.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, stubAccount.Balance);
        }

        [TestMethod]
        public void AddingTwoTransactionsCreatesSummationBalance()
        {
            // Arrange
            stubAccount.AddTransaction(50m);

            // Act
            stubAccount.AddTransaction(75m);

            // Assert
            Assert.AreEqual(125m, stubAccount.Balance);
        }

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Account();

            // using Moq
            //var mockRepository = new Mock<IAccountRepository>();
            //mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account);
            //var sut = new AccountService(mockRepository.Object); // sutにmockを提供する

            using (ShimsContext.Create())
            {
                // Arrange
                stubAccount.AddTransaction(1000m);
                // StubIAccountRepository mockRepository = new StubIAccountRepository();
                stubRepository.GetByNameString = str =>
                {
                    if (str == "trading")
                        return stubAccount;
                    else
                        return null;
                };
                var sut = new AccountService(stubRepository);

                // Act
                sut.AddTransactionToAccount("trading", 300m);

                // Assert
                Assert.AreEqual(1300m, stubAccount.Balance);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullAccountRepository()
        {
            // Arrange

            // Act
            new AccountService(null);

            // Assert

        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Arrange
            // var mockRepository = new StubIAccountRepository();
            var sut = new AccountService(stubRepository);

            // Act
            sut.AddTransactionToAccount("trading", 100m);

            // Assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            shimAccount.AddTransactionDecimal = (r) => { throw new DomainException(); };
            stubRepository.GetByNameString = str => { return shimAccount; };
            sut = new AccountService(stubRepository);

            // Act
            try
            {
                sut.AddTransactionToAccount("trading", 200m);
            }
            catch (ServiceException ex)
            {
                // Assert
                Console.WriteLine(ex.InnerException.ToString());
                Assert.IsInstanceOfType(ex.InnerException, typeof(DomainException));
            }
        }
    }
}