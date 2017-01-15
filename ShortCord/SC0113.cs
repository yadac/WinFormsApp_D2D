using System;
using System.IO;

namespace ShortCord
{
    public class SC0113
    {
        public SC0113()
        {
            string[] args = {"adachi", "yosuke"};
            this.MyMethod(args);
        }

        public void MyMethod(string[] args)
        {
            TextWriter writer = Console.Out;
            Action close = () => { };
            if (args.Length > 0)
            {
                writer = File.CreateText(args[0]);
                close = () => { writer.Close(); };
            }
            writer.WriteLine("hello c#!");
            close();
        }
    }
}