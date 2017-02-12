using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    public class Sca005
    {
        private const char Separator = '=';

        public Sca005()
        {
            // temp
            var section = string.Empty;
            var key = string.Empty;
            var val = string.Empty;
            var dictionary1 = new Dictionary<string, Dictionary<string, string>>();
            var dictionary2 = new Dictionary<string, string>();

            // read ini file
            var textFile = @"c:\temp\sample.ini";
            var enc = Encoding.GetEncoding("shift_jis");
            var lines = File.ReadAllLines(textFile, enc);

            // store key value pair to dictionary
            foreach (var line in lines)
            {
                var item = line.Split(Separator);
                // section
                if (item.Length == 1)
                {
                    Console.WriteLine(section);
                    if (!dictionary1.ContainsKey(section))
                        dictionary1.Add(section, dictionary2);
                    section = item[0];
                    dictionary2.Clear();
                }
                // key=value
                if (item.Length == 2)
                {
                    key = item[0];
                    val = item[1];
                    dictionary2.Add(key, val);
                }
            }
            foreach (var item in dictionary1)
            {
                foreach (var dic in item.Value)
                {
                    Console.WriteLine($"key={dic.Key}, value={dic.Value}");
                }
            }
        }
    }
}
