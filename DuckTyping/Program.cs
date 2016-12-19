using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;


namespace DuckTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            Swan swan = new Swan();
            var swanAsDuck = swan as IDuck;
            if (swan is IDuck || swanAsDuck != null)
            {
                swan.Walk();
                swan.Swim();
                swan.Quack();
            }
            Console.ReadLine();
        }
    }

    public interface IDuck
    {
        void Walk();
        void Swim();
        void Quack();
    }

    public class Swan
    {
        public void Walk()
        {
            Console.WriteLine("the swan is walking");
        }

        public void Swim()
        {
            Console.WriteLine("the swan can swim like a duck.");
        }

        public void Quack()
        {
            Console.WriteLine("the swan is quacking.");
        }
    }

    
}
