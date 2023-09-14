using Projeto.Models;
using Projeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto.Interfaces
{
    public interface ITransactionLogger
    {
        void LogTransaction(TransactionData transactionData, StatusTransacao status);
    }
}
