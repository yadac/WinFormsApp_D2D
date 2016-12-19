using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixIn
{
    class Program
    {
        static void Main(string[] args)
        {
            MixinClient mc = new MixinClient(new Swan());
            mc.Run();
            Console.ReadLine();
        }
    }

    public class Swan : ITargetInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("swan swan swan.");
        }
    }

    public interface ITargetInterface
    {
        void DoSomething();
    }

    public static class MixinExtensions
    {
        public static void FirstExtensionMethod(this ITargetInterface target)
        {
            Console.WriteLine("the first extension method was called.");
        }

        public static void SecondExtensionMethod(this ITargetInterface target)
        {
            Console.WriteLine("the second extension method was called.");
        }
    }

    public static class MoreMixinExtensions
    {
        public static void FurtherExtensionMethodA(this ITargetInterface target, int extraParameter)
        {
            Console.WriteLine("further extension method A was called with argument {0}", extraParameter);
        }

        public static void FurtherExtensionMethodB(this ITargetInterface target, string stringParameter)
        {
            Console.WriteLine("further extension method B was called with argument {0}", stringParameter);
        }
    }

    public class MixinClient
    {
        private readonly ITargetInterface _target;

        public MixinClient(ITargetInterface target)
        {
            _target = target;
        }

        public void Run()
        {
            _target.DoSomething();
            // 第一引数を指定していないのに呼べる！さもITargetInterfaceに定義されているかのように！
            // 拡張メソッドとは
            // https://msdn.microsoft.com/ja-jp/library/bb383977.aspx
            // 静的クラス
            // thisで修飾
            _target.FirstExtensionMethod();
            _target.SecondExtensionMethod();
            _target.FurtherExtensionMethodA(30);
            _target.FurtherExtensionMethodB("hello!");
        }
    }
}
