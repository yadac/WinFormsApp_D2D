using System;
using System.Threading.Tasks;

namespace ShortCord
{
    static class A
    {
        private static readonly string three;
        static A()
        {
            Console.WriteLine("two");
            three = "three";
        }

        public static void Three()
        {
            Console.WriteLine(three);
        }
    }

    static class B
    {
        private static int maru;
        static B()
        {
            Console.WriteLine("initialized static class B now");
        }

        public static void Dummy() { } // ダミー処理
    }

    public class SC0118
    {
        public SC0118()
        {
            Console.WriteLine("one");
            A.Three(); // 静的なクラスは使用するまで初期化されない
            Task.Delay(5000).Wait();
            B.Dummy();
        }
    }
}