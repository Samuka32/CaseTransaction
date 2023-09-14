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
        public long ContaOrigem { get; }
        public long ContaDestino { get; }
        public decimal Valor { get; }

        public TransactionData(int correlationId, string dateTime, long contaOrigem, long contaDestino, decimal valor)
        {
            CorrelationId = correlationId;
            DateTime = dateTime;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
