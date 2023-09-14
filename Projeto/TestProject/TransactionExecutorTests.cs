using Projeto.Repository;
using Telerik.JustMock;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Models;
using Projeto.Commons.Logger;
using Projeto.Services;
using Projeto.Models.Enums;
using System.Security.Principal;

namespace TestProject
{
    public class TransactionExecutorTests
    {
        [Fact]
        public void TestProcessTransaction()
        {
            //Arrange
            var mockDataAccess = Mock.Create<IDataAccess>();
            var mockTransaction = Mock.Create<ITransactionLogger>();
            Mock.Arrange(() => mockDataAccess.GetBalance<Account>(1)).Returns(new Account());
            Mock.Arrange(() => mockDataAccess.GetBalance<Account>(2)).Returns(new Account());
            var executorTest = new TransactionExecutor(mockDataAccess, new SerilogTransactionLogger());
            //Act
            var erro = Record.Exception(() => executorTest.ProcessTransaction(new TransactionData(1, "09/09/2023 14:15:00", 1, 2, 150)));
            //Assert
            Assert.Null(erro);

        }
        [Fact]
        public void TestExchangeBalance()
        {
            //Arrange
            var mockDataAccess = Mock.Create<IDataAccess>();
            var mockTransaction = Mock.Create<ITransactionLogger>();
            Mock.Arrange(() => mockDataAccess.GetBalance<Account>(1)).Returns(new Account(1, 100));
            Mock.Arrange(() => mockDataAccess.GetBalance<Account>(2)).Returns(new Account(2, 200));
            var transactionData = new TransactionData(1, DateTime.Now.ToString(), 1, 2, 50);
            var executorTest = new TransactionExecutor(mockDataAccess, new SerilogTransactionLogger());
            var account1 = new Account(1, 100);
            var account2 = new Account(2, 100);
            //Act
            var erro = Record.Exception(() => executorTest.ExchangeBalance(transactionData, account1, account2));
            //Assert
            Assert.Equal(50, account1.Balance);
        }
    }
}
