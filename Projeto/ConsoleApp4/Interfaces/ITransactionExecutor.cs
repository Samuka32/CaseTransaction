using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Interfaces
{
    public interface ITransactionExecutor
    {
        void ExecuteTransaction(TransactionData transactionData);
    }
}
