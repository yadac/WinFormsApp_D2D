using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    public class SCA004
    {
        private const string Msgid = "MSG1111";

        public void DoSomething(int count, int i)
        {
            var newCount = countUp(count);
        }

        private int countUp(int count)
        {
            return count + 1;
        }

        private static void UnUseMethod()
        {
        }
    }
}
