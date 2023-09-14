using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models.Enums
{
    public enum StatusTransaction
    {
        Success,
        InsufficientFunds,
        OriginAccountNotFound,
        DestinationAccountNotFound
    }
}
