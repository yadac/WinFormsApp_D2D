using System;
using System.Linq;

namespace ShortCord
{
    public class SC0203
    {
        public SC0203()
        {
            var s = Enumerable.Range(1, 7);
            var q = s.SelectMany(c => s, (n, m) => string.Format("{0,7}{1}", Math.Pow(n, m), m == 7 ? "\n" : ""));
            foreach (var n in q) Console.WriteLine(n);

            // 1-3の掛け算全組み合わせ
            var array1 = Enumerable.Range(1, 3);
            var array2 = Enumerable.Range(1, 10);
            var query = array1.SelectMany(c => array1, (n, m) => string.Format("{0} x {1} = {2}", n, m, n * m));
            foreach (var res in query) Console.WriteLine(res);
        }
    }
}