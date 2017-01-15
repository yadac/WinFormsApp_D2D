using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace ShortCord
{
    public class SC0202
    {
        public SC0202()
        {
            foreach (var i in Enumerable.Range(0,10)) Console.WriteLine(i);
        }
    }
}