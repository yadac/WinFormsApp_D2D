using System;

namespace ShortCord
{
    public class SC0109 : ISampleCode
    {
        public SC0109()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            Validtype a;
            // if fail parse, a will be initialized by zero, it means invalid.
            Enum.TryParse<Validtype>("はてな", out a);
            Console.WriteLine(a);
        }

        private enum Validtype
        {
            Valid = 1,
            Invalid = 0,
        }
    }
}