using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    public class MyClass
    {
        public static int MyMethod()
        {
            return 100;
        }

        public int MyMethod2()
        {
            throw new NotImplementedException();
        }

        public void MyMethod3(int amount)
        {
            throw new NotImplementedException();
        }

        public bool MyMethod4(string name, int amount)
        {
            return true;
        }
    }
}
