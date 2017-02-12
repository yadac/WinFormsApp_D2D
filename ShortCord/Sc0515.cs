using System;
using System.Collections.Generic;

namespace ShortCord
{
    public class Sc0515
    {
        public Sc0515()
        {
            List<string> list = new List<string>() { "hello", "c#" };
            string[] array = list.ToArray();
            List<string> listAgain = new List<string>();
            listAgain.AddRange(array);
            foreach (var n in listAgain) Console.WriteLine(n);
        }
    }
}