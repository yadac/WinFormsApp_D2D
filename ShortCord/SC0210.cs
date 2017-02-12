using System;

namespace ShortCord
{
    public class SC0210
    {
        public SC0210()
        {
            using (SC0210A a = new SC0210A())
            {
                a.Hello();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("dispose");
        }
    }

    public class SC0210A : IDisposable
    {
        public SC0210A()
        {
            Console.WriteLine("initialize");
        }

        public void Hello()
        {
            Console.WriteLine("hello");
        }

        public void Dispose()
        {
            Console.WriteLine("disposed");
        }
    }
}