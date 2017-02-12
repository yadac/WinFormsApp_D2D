using System;
using System.Linq;

namespace ShortCord
{
    public class Sc0414
    {
        public Sc0414()
        {
            object[] a = { 1, 2, 3, "font", TimeSpan.FromHours(5) };
            foreach (var item in a.OfType<string>()) Console.WriteLine(item.ToUpper());
        }
    }
}