using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Human
    {
        public string name;
        public int height = -1;

        public Human(string name, int height)
        {
            this.name = name;
            this.height = height;
        }
    }

    public class SampleClass
    {
        public int Compare(Human h1, Human h2)
        {
            if (h1.name == h2.name)
                return 1;
            if (h1.height > h2.height)
            { 
                return 2;
            }
            return 3;
        }
    }
    // 戦略を委譲
    // 委譲先はインタフェースで契約
}
