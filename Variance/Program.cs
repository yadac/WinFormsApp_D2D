using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variance
{
    public interface ISample1<in T>
    {
        void SetValue(T t);
    }

    public interface ISample2<out T>
    {
        T GetValue();
    }

    public class A { }
    public class B : A { }
    public class C : B { }

    public class Sample1<T> : ISample1<T>
    {
        public void SetValue(T t)
        {
            Console.WriteLine("setting:{0}", t);
        }
    }

    public class Sample2<T> : ISample2<T>
    {
        public T GetValue()
        {
            return default(T);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // 1)sample1はisample1を実装しているから代入可能
            // 2)b→cというのは継承関係が逆なんだけど？？？
            ISample1<C> c = new Sample1<B>();
            // 1)は同じ
            // 2)はAのdefaultはBのdefaultとは異なるが？？？
            ISample2<A> a = new Sample2<B>();
            c.SetValue(new C());
            Console.WriteLine(a.GetValue());
        }
    }
}
