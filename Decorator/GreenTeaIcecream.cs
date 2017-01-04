using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
public    class GreenTeaIcecream : ICecream
    {
        public string GetName()
        {
            return "GreenTea Icecream";
        }

        public string HowSweet()
        {
            return "Greentea flavor";
        }
    }
}
