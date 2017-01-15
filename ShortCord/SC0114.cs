using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShortCord
{
    public class SC0114
    {
        public SC0114()
        {
            this.Greeting(() => { Console.WriteLine("旦那様"); });
            this.Greeting(() => { Console.WriteLine("おじょう様"); });
        }

        public void Greeting(Action action)
        {
            Console.WriteLine("open the door");
            action();
            Console.WriteLine("close the door");
        }
    }

    public class SC0115
    {
        private IEnumerable<int> q;

        public SC0115()
        {
            string[] args = { "c:temp" };
            this.MyMethod(args);
        }

        public void MyMethod(string[] args)
        {
            int[] ar = { 1, 0 };
            var q = from n in ar select n;
            if (q.Any((c) => c <= 0))
            {
                Console.WriteLine("結果が0以下の結果が含まれます。データが正しくありません。");
                return;
            }
            using (var writer = File.CreateText(args[0]))
            {
                foreach (var n in q)
                {
                    writer.WriteLine(100 / n);
                }
            }
        }
    }
}