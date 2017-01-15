using System;

namespace ShortCord
{
    public static class SC0104
    {
        public static void SayHello(string name = "taro", int age = -1)
        {
            Console.WriteLine($"{age}才の{name}さん");
        }
    }
}