using Projeto.Models;
using Projeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto.Commons.Logger
{
    public interface ITransactionLogger
    {
        void LogTransaction(TransactionData transactionData, StatusTransaction status);
        void LogTransactionError(TransactionData transactionData, Exception e);
    }
}
