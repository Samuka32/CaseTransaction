using Projeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto.Models
{
    public class Account
    {
        public long Number { get; set; }
        public decimal Balance { get; private set; }

        public Account()
        {
        }

        public Account(long number, decimal value)
        {
            Number = number;
            Balance = value;
        }

        public void AddBalance(decimal value) 
        {
            Balance += value;
        }

        public void DecreaseBalance(decimal value)
        {
            if (value > Balance)
            {
                throw new Exception(StatusTransaction.InsufficientFunds.ToString());
            }
            Balance -= value;
        }

        public Account Clone()
        {
            return new Account(Number, Balance);
        }
    }
}
