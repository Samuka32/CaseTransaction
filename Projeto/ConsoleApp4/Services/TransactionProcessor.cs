using Projeto.Interfaces;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace Projeto.Services
{
    public class TransactionProcessor
    {
        private readonly IDataAccess _dataAccess;
        private readonly ITransactionLogger _transactionLogger;

        public TransactionProcessor(IDataAccess dataAccess, ITransactionLogger transactionLogger)
        {
            _dataAccess = dataAccess;
            _transactionLogger = transactionLogger;
        }

        public void ProcessTransaction(TransactionData transactionData)
        {
            var executor = new TransactionExecutor(_dataAccess, _transactionLogger);
            executor.ExecuteTransaction(transactionData);
        }
    }
}
