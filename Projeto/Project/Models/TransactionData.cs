using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class TransactionData
    {
        public int CorrelationId { get; }
        public string DateTime { get; }
        public long OriginAccount { get; }
        public long DestinationAccount { get; }
        public decimal Value { get; }

        public TransactionData(int correlationId, string dateTime, long originAccount, long destination, decimal value)
        {
            CorrelationId = correlationId;
            DateTime = dateTime;
            OriginAccount = originAccount;
            DestinationAccount = destination;
            Value = value;
        }
    }
}
