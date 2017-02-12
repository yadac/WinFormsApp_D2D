using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    public class Sc0403
    {
        public Sc0403()
        {
            var a = new Dictionary<int, string>();
            a.Add(1, "taro");
            string r;
            Console.WriteLine(a.TryGetValue(2, out r) ? r : "not found" );
            Console.WriteLine(r ?? "not found");
        }
    }
}
