using System;

namespace ShortCord
{
    public class SC0107 : ISampleCode
    {
        public SC0107()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            string src = "adachi";
            int result;
            Console.WriteLine(int.TryParse(src, out result) ? result : -1);
        }
    }
}