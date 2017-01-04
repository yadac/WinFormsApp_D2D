using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class SecondTypeOfLeaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine("second type of leaf");
        }
    }
}
