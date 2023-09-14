using NMemory.Transactions.Logs;
using Projeto.Interfaces;
using Projeto.Models;
using Projeto.Services;
using System;
using System.Transactions;
using Xunit;

public class TransactionExecutorTests
{
    [Fact]
    public void ExecuteTransaction_WithValidTransaction_ShouldUpdateBalancesAndLogSuccess()
    {
        // Arrange
        var dataAccess = new DataAccess();
        var transactionLogger = new InMemoryTransactionLogger();
        var executor = new TransactionExecutor(dataAccess, transactionLogger);

        var transactionData = new TransactionData(1, "09/09/2023 14:15:00", 938485762, 2147483649, 50);

        // Act
        executor.ExecuteTransaction(transactionData);

        // Assert
        var origemSaldo = dataAccess.GetSaldo<ContaSaldo>(938485762);
        var destinoSaldo = dataAccess.GetSaldo<ContaSaldo>(2147483649);

        Assert.Equal(130, origemSaldo.Saldo);
        Assert.Equal(50, destinoSaldo.Saldo);

        Assert.Collection(transactionLogger.LoggedTransactions,
            log => Assert.Equal(TransactionStatus.Success, log.Status)
        );
    }

    [Fact]
    public void ExecuteTransaction_WithInsufficientFunds_ShouldCancelTransactionAndLogInsufficientFunds()
    {
        // Arrange
        var dataAccess = new DataAccess();
        var transactionLogger = new InMemoryTransactionLogger();
        var executor = new TransactionExecutor(dataAccess, transactionLogger);

        var transactionData = new TransactionData(2, "09/09/2023 14:15:05", 938485762, 2147483649, 200);

        // Act
        executor.ExecuteTransaction(transactionData);

        // Assert
        var origemSaldo = dataAccess.GetSaldo<ContaSaldo>(938485762);
        var destinoSaldo = dataAccess.GetSaldo<ContaSaldo>(2147483649);

        Assert.Equal(180, origemSaldo.Saldo);
        Assert.Equal(0, destinoSaldo.Saldo);

        Assert.Collection(transactionLogger.LoggedTransactions,
            log => Assert.Equal(TransactionStatus.InsufficientFunds, log.Status)
        );
    }

    // Add more test cases for edge scenarios
}

public class InMemoryTransactionLogger : ITransactionLogger
{
    public List<TransactionLog> LoggedTransactions { get; } = new List<TransactionLog>();

    public void LogTransaction(TransactionData transactionData, TransactionStatus status)
    {
        LoggedTransactions.Add(new TransactionLog(transactionData.CorrelationId, status));
    }
}