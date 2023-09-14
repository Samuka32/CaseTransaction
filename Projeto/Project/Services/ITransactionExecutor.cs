using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public interface ITransactionExecutor
    {
        void ProcessTransaction(TransactionData transactionData);
    }
}
