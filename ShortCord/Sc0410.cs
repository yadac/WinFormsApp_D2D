using System;
using System.Collections.Generic;

namespace ShortCord
{
    public class Sc0410
    {
        public Sc0410()
        {
            var dic = new Dictionary<int, string>()
            {
                {1,"first" }, {2, "second" }, {3,"third" }
            };
            foreach (var n in dic.Keys)
            {
                Console.WriteLine(dic[n]);
            }
            foreach (var n in dic.Values)
            {
                Console.WriteLine(n);
            }
        }
    }
}