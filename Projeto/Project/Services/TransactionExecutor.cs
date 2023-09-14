using Projeto.Commons.Logger;
using Projeto.Models;
using Projeto.Models.Enums;
using Projeto.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void ProcessTransaction(TransactionData transactionData)
        {
            var orignAccount = _dataAccess.GetBalance<Account>(transactionData.OriginAccount);
            var destinationAccount = _dataAccess.GetBalance<Account>(transactionData.DestinationAccount);

            if (orignAccount is null)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransaction.OriginAccountNotFound);
                return;
            }

            if (orignAccount.Balance < transactionData.Value)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransaction.InsufficientFunds);
                return;
            }

            if (destinationAccount is null)
            {
                _transactionLogger.LogTransaction(transactionData, StatusTransaction.DestinationAccountNotFound);
                return;
            }

            ExchangeBalance(transactionData,orignAccount, destinationAccount);            

            _transactionLogger.LogTransaction(transactionData, StatusTransaction.Success);
        }

        public void ExchangeBalance(TransactionData transactionData, Account origin, Account destination)
        {
            //Pela falta de db temos o rollback
            Account oldOrigin = origin.Clone();
            Account oldDestination = destination.Clone();
            origin.DecreaseBalance(transactionData.Value);            
            destination.AddBalance(transactionData.Value);
            try
            {
                _dataAccess.Update(origin);
                _dataAccess.Update(destination);
            }
            catch (Exception e)
            {
                _dataAccess.Update(oldOrigin);
                _dataAccess.Update(destination);
                Log.Warning("Could not update accounts : {Conta} {Conta}/n Error: {e}", origin,destination, e.Message);
            }
            
        }
    }
}
