using Projeto.Models.Enums;
using Projeto.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Commons.Logger
{
    public class SerilogTransactionLogger : ITransactionLogger
    {
        public void LogTransaction(TransactionData transactionData, StatusTransaction status)
        {
            Log.Information("Transaction ID: {CorrelationId}, Status: {Status}", transactionData.CorrelationId, status);
        }

        public void LogTransactionError(TransactionData transactionData, Exception e)
        {
            Log.Warning("Transaction ID: {CorrelationId}, Status: {Status}", "Error : {e}", transactionData.CorrelationId, e.Message);
        }

    }

}
