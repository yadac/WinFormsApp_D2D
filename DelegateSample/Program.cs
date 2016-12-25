using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(){
                "Taro",
                "Jiro",
                "Saburo",
                "Umeko",
                "Takeko",
                "Matsuko",
            };

            Func<string, bool> predicate;

            // stringを引数にとって、boolを戻り値で返すデリゲート
            // デリゲートの実態をわざわざ定義するが面倒　→　匿名
            // Func<string, bool> predicate = DelegateSampleMain.IsLengthLessThan5;

            // c#2.0での改善：匿名メソッドによる定義場所の変更
            predicate = delegate (string str)
            {
                return str.Length < 5;
            };

            // c#3.0での改善：ラムダ式による
            // delegateキーワードがなくなって => が登場
            predicate = (string str) =>
            {
                return str.Length < 5;
            };

            // 短い版
            predicate = str => str.Length < 5;

            // int count = DelegateSampleMain.CountList(names, predicate);
            int count = DelegateSampleMain.CountList(names, str => str.Length < 5);

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
