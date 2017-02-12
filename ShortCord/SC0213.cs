using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShortCord
{
    public class SC0213
    {
        public SC0213()
        {
            int[] ar = { 1, 2, 3 };
            ar = ar.Where(c => c != 2).ToArray();
            foreach (var n in ar) Console.WriteLine(n);
        }
    }
}