using System;
using System.Linq;

namespace ShortCord
{
    public class Sc0409
    {
        public Sc0409()
        {
            var random = new Random(0);
            int[] a = Enumerable.Repeat(0, 5).Select(c => random.Next()).ToArray();
            foreach (var n in a) Console.WriteLine(n);
        }
    }
}