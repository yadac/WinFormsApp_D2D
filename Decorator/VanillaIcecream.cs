using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class VanillaIcecream : ICecream
    {
        public virtual string GetName()
        {
            return "vanilla icecream";
        }

        public string HowSweet()
        {
            return "vanilla sweet";
        }
    }
}
