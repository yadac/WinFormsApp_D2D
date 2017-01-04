using System;
using System.Diagnostics;

namespace Composite
{
    internal class Program
    {
        private static IComponent component;
        public static ILogger logger = new Log4NetLoggerAdapter();

        private static void Main(string[] args)
        {
            var composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondTypeOfLeaf());
            composite.AddComponent(new PredicatedDecoratorExample(
                new PredicateComponent(
                    new ConcreateComponent(),
                    new TodayIsAnEvenDayOfTheMonth(
                        new DateTester()))));

            composite.AddComponent(new ProfilingComponent(
                new SlowComponent(),
                new LoggingStopwatch(
                    new StopwatchAdapter(
                        new Stopwatch()))));

            Console.WriteLine("----------");
            composite.AddComponent(new MainWindowViewModel(
                new AsyncComponent(
                    new SampleTaskComponent())));

            // composite = 複合物
            component = composite;
            component.Something();

            Console.ReadLine();
        }
    }
}