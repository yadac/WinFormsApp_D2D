using System;

namespace Composite
{
    public class ConcreateCalculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class LoggingCalculator : ICalculator
    {
        private readonly ICalculator calculator;

        public LoggingCalculator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public int Add(int x, int y)
        {
            Console.WriteLine("Add(x = {0}, y = {1}", x, y);
            var result = calculator.Add(x, y);
            Console.WriteLine("result = {0}", result);
            return result;
        }
    }
}