using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortCord
{
    public class Sc0501
    {
        public Sc0501()
        {
            // old code
            int[] a = { 1, 2, 3, 4 };
            var r = Sc0501MyMthod(a);
            foreach (var n in r) Console.WriteLine(n);

            // new code
            foreach (var item in a.Where(c => c > 2))
                Console.WriteLine(item.ToString());
        }

        private int[] Sc0501MyMthod(int[] ar)
        {
            var list = new List<int>();
            foreach (var n in ar) if (n > 2) list.Add(n);
            return list.ToArray();
        }
    }
}