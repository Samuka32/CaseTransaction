using Projeto.Interfaces;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly Dictionary<long, ContaSaldo> _contaSaldos = new Dictionary<long, ContaSaldo>();

        public DataAccess()
        {
            _contaSaldos.Add(938485762, new ContaSaldo(938485762, 180));
            _contaSaldos.Add(2147483649, new ContaSaldo(2147483649, 0));
            _contaSaldos.Add(347586970, new ContaSaldo(347586970, 1200));
            _contaSaldos.Add(238596054, new ContaSaldo(238596054, 478));
            _contaSaldos.Add(675869708, new ContaSaldo(675869708, 4900));
            _contaSaldos.Add(210385733, new ContaSaldo(210385733, 10));
            _contaSaldos.Add(674038564, new ContaSaldo(674038564, 400));
            _contaSaldos.Add(563856300, new ContaSaldo(563856300, 1200));
            _contaSaldos.Add(573659065, new ContaSaldo(573659065, 787));

            // Add other account balances here
        }

        public T GetSaldo<T>(long id) where T : ContaSaldo
        {
            return _contaSaldos.ContainsKey(id) ? (T)_contaSaldos[id] : null;
        }

        public T GetSaldo<T>(int id) where T : ContaSaldo
        {
            throw new NotImplementedException();
        }

        public bool Update(ContaSaldo dado)
        {
            try
            {
                _contaSaldos[dado.Conta] = dado;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
