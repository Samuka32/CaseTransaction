using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository
{
    public interface IDataAccess
    {
        T GetBalance<T>(long number) where T : Account ;
        void Update(Account data);
    }
}
