using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class CashewNutsToppingIcecream : ICecream
    {
        private readonly ICecream ice;

        public CashewNutsToppingIcecream(ICecream ice)
        {
            this.ice = ice;
        }

        public string GetName()
        {
            string name = "CashewNuts";
            name += ice.GetName();
            return name;
        }

        public string HowSweet()
        {
            return ice.HowSweet();
        }
    }
}
