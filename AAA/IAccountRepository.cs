using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    public interface IAccountRepository
    {
        Account GetByName(string name);
    }
}
