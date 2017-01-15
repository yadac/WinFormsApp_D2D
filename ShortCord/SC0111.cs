using System;

namespace ShortCord
{
    public class SC0111 : ISampleCode
    {
        public SC0111()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            string s = "hello";
            Console.WriteLine(s ?? "(null)");
        }
    }
}