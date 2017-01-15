using System;
using System.Linq;

namespace ShortCord
{
    public class SC0105
    {
        public SC0105()
        {
            string[] a = { "ichiro", "jiro", "saburo" };
            foreach (var name in a.Select((s, i) => new { i, s }))
                Console.WriteLine($"{name.s}さんは{name.i + 1}位");
        }
    }
}