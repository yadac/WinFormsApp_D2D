using System;

namespace ShortCord
{
    public class SC0301
    {
        public SC0301()
        {
            var now = new DateTime(2017, 1, 1);
            Console.WriteLine("{0:yyyy-MM-dd}", now.AddMonths(-1));
            Console.WriteLine("{0:yyyy-MM-dd}", now.AddDays(-1));
            
        }
    }
}