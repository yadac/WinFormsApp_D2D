using System;

namespace ShortCord
{
    public class Sc1208
    {
        class MyValue
        {
            internal int A;
            internal double B;
            internal string C;
        }

        private static Tuple<int, double, string> GetValue()
        {
            return new Tuple<int, double, string>(123, 4.56, "789");
        }

        //private static MyValue GetValue()
        //{
        //    return new MyValue() { A = 123, B = 4.56, C = "789" };
        //}

        public Sc1208()
        {
            var Val = GetValue();
            //Console.WriteLine($"{Val.A}, {Val.B}, {Val.C}");
            Console.WriteLine($"{Val.Item1}, {Val.Item2}, {Val.Item3}");
        }
    }
}