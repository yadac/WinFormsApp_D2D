using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    public class SC0401
    {
        public SC0401()
        {
            try
            {
                //var a = MyMethod();
                //Array.Sort(a);
                //int[] found = Array.FindAll(a, (c) => c > 0);
                //foreach (var i in found)
                //{
                //    Console.WriteLine(i);
                //}
                foreach (var n in MyMethod().Where(c => c > 0).OrderBy(c => c))
                {
                    Console.WriteLine(n);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<int> MyMethod()
        {
            // return new List<int>() { 3, 1, 2, 0 }.ToArray();
            yield return 3;
            yield return 1;
            yield return 2;
            yield return 0;
        }
    }
}
