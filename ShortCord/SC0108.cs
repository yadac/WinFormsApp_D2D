using System;

namespace ShortCord
{
    public class SC0108 : ISampleCode
    {
        public SC0108()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            string src = "adachi";
            int result;
            int.TryParse(src, out result); // false then zero
            Console.WriteLine(result);
        }
    }
}