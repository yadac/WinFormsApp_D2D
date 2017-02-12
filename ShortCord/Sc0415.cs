using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortCord
{
    public class Sc0415
    {
        public Sc0415()
        {
            var list = new List<string>() { "zero" };
            list.AddRange(Enumerable.Range(1, 3).Select(c => c.ToString()));
            foreach (var item in list) Console.WriteLine(item);

            object[] array = { "one", 2, "three" };
            list.AddRange(array.OfType<string>());
            foreach (var item in list) Console.WriteLine(item);
        }
    }
}