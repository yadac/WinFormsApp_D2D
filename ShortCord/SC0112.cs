using System;

namespace ShortCord
{
    public class SC0112 : ISampleCode
    {
        public SC0112()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            var sample = new Example()
            {
                a = "{0}{1}",
                b = "this is b!",
                c = "this is c!",
            };
            Console.WriteLine(sample.a, sample.b, sample.c);
        }
    }

    class Example
    {
        internal string a, b, c;
    }
}