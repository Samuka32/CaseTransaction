using Projeto.Interfaces;
using Projeto.Models;
using Projeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Program;

namespace Projeto.Services
{
    public class TransactionExecutor : ITransactionExecutor
    {
        private readonly IDataAccess _dataAccess;
        private readonly ITransactionLogger _transactionLogger;

        public TransactionExecutor(IDataAccess dataAccess, ITransactionLogger transactionLogger)
        {
            _dataAccess = dataAccess;
            _transactionLogger = transactionLogger;
        }

        public void ExecuteTransaction(TransactionData transactionData)
        {
            var contaSaldoOrigem = _dataAccess.GetSaldo<ContaSaldo>(transactionData.ContaOrigem);

            if (contaSaldoOrigem == null)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransacao.OriginAccountNotFound);
                return;
            }

            if (contaSaldoOrigem.Saldo < transactionData.Valor)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransacao.InsufficientFunds);
                return;
            }

            var contaSaldoDestino = _dataAccess.GetSaldo<ContaSaldo>(transactionData.ContaDestino);

            if (contaSaldoDestino == null)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransacao.DestinationAccountNotFound);
                return;
            }

            contaSaldoOrigem.Saldo -= transactionData.Valor;
            contaSaldoDestino.Saldo += transactionData.Valor;

            _dataAccess.Update(contaSaldoOrigem);
            _dataAccess.Update(contaSaldoDestino);

            _transactionLogger.LogTransaction(transactionData, StatusTransacao.Success);
        }
    }
}
