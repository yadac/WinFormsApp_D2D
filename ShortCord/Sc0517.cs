using System;
using System.Linq;

namespace ShortCord
{
    public class Sc0517
    {
        public Sc0517()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5 };
            b = a.Concat(b).ToArray();
            foreach (var n in b) Console.WriteLine(n);
        }
    }
}