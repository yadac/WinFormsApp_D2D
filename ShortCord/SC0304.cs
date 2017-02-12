using System;

namespace ShortCord
{
    public class SC0304
    {
        public SC0304()
        {
            var len = 120;
            // var ts = new TimeSpan(0, len, 0);
            var ts = TimeSpan.FromMinutes(len);
            Console.WriteLine("{0}分テープには{1}録画できます", len, ts);
        }
    }
}