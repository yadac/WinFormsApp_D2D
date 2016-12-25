using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class DelegateSampleMain
    {
        public static int CountList<T>(List<T> list, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (var element in list)
            {
                if (predicate(element))
                {
                    count++;
                }
            }
            return count;
        }

        public static bool IsLengthLessThan5(string str)
        {
            return str.Length < 5;
        }
    }
}
