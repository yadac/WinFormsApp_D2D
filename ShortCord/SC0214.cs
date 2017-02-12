using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortCord
{
    public class SC0214
    {
        public SC0214()
        {
            int[] ar = { 1, 2, 3 };
            ar = ar.Concat(new int[] {4}).Concat(ar.Skip(1)).ToArray();
            foreach (var n in ar) Console.WriteLine(n);
        }
    }
}