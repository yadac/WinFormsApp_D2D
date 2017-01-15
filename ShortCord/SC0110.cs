using System;

namespace ShortCord
{
    public class SC0110
    {
        public SC0110()
        {
            Console.WriteLine(this.myMethod(100));
            Console.WriteLine(this.myMethod(101));
        }

        private bool myMethod(int x)
        {
            return x > 100;
        }
    }
}