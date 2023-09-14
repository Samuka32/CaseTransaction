using Projeto.Models;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.SystemConsole;
using Projeto.Commons.Logger;

namespace Projeto.Repository
{
    public class DataAccess : IDataAccess
    {
        private readonly Dictionary<long, Account> _accounts = new Dictionary<long, Account>();
        public DataAccess()
        {
            _accounts.Add(938485762, new Account(938485762, 180));
            _accounts.Add(2147483649, new Account(2147483649, 0));
            _accounts.Add(347586970, new Account(347586970, 1200));
            _accounts.Add(238596054, new Account(238596054, 478));
            _accounts.Add(675869708, new Account(675869708, 4900));
            _accounts.Add(210385733, new Account(210385733, 10));
            _accounts.Add(674038564, new Account(674038564, 400));
            _accounts.Add(563856300, new Account(563856300, 1200));
            _accounts.Add(573659065, new Account(573659065, 787));
        }

        public T GetBalance<T>(long account) where T : Account
        {
            return _accounts.ContainsKey(account) ? (T)_accounts[account] : (T)(new Account());
        }

        public void Update(Account data)
        {
            try
            {
                _accounts[data.Number] = data;
            }
            catch (Exception e)
            {
                Log.Error("Could not update account : {Conta} /n Error: {e}", data.Number, e.Message);
                throw;
            }
        }
    }
}
