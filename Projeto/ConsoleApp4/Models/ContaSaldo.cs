using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class ContaSaldo
    {
        public long Conta { get; set; }
        public decimal Saldo { get; set; }

        public ContaSaldo()
        {
        }

        public ContaSaldo(long conta, decimal valor)
        {
            Conta = conta;
            Saldo = valor;
        }
    }
}
