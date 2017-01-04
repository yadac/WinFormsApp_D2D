using System;
using System.Diagnostics;

namespace Composite
{
    public class ProfilingComponent : IComponent
    {
        private readonly IStopwatch stopwatch;
        private readonly IComponent decoratedComponent;

        public ProfilingComponent(IComponent decoratedComponent, IStopwatch stopwatch)
        {
            this.decoratedComponent = decoratedComponent;
            this.stopwatch = stopwatch;
        }

        public void Something()
        {
            stopwatch.Start();
            decoratedComponent.Something();
            Console.WriteLine("the method took {0} seconds to complete", stopwatch.Stop());
        }
    }
}