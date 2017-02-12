using System;
using System.Globalization;

namespace ShortCord
{
    public class SCA003
    {
        public SCA003()
        {
            Console.WriteLine(DateTime.Now.ToString("d"));
            // invariantinfo = カルチャ非依存
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd"));
            CultureInfo ci = new CultureInfo("en-US");
            Console.WriteLine(DateTime.Now.ToString("d", ci));
        }
    }
}