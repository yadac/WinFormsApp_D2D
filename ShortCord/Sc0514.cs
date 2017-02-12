using System;
using System.Collections;

namespace ShortCord
{
    public class Sc0514
    {
        public Sc0514()
        {
            Item514[] a = {new Item514(2), new Item514(1), new Item514(3),};
            // Array.Sort(a, new MyComparar());
            Array.Sort(a, (x, y) => x.A - y.A);
            foreach (var n in a) Console.WriteLine(n.A);
        }
    }

    public class MyComparar : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((Item514) x).A - ((Item514) y).A;
        }
    }

    public class Item514
    {
        public int A { get; set; }

        public Item514(int a)
        {
            A = a;
        }
    }
}