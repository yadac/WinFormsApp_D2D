using System;
using System.Collections;
using System.Collections.Generic;

namespace ShortCord
{
    public class SC0201
    {
        public SC0201()
        {
            foreach (var n in new Sample()) Console.WriteLine(n);
        }
    }

    class Sample : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 10; i++) yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}