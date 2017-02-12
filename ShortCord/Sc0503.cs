using System;
using System.Linq;

namespace ShortCord
{
    public class Sc0503
    {
        public Sc0503()
        {
            int[] a = { 1, 2, 3, 4 };
            Console.WriteLine(a.FirstOrDefault(c => c > 2));
        }
    }
}