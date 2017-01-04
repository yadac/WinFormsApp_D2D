using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICecream ice1 = new CashewNutsToppingIcecream(new VanillaIcecream());
            Console.WriteLine("name is {0}, flavor is {1}", ice1.GetName(), ice1.HowSweet());
            Console.ReadLine();
        }
    }
}
