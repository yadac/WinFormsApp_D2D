using System;
using System.Threading;

namespace Composite
{
    public class SlowComponent : IComponent
    {
        private readonly Random random;

        public SlowComponent()
        {
            random = new Random((int) DateTime.Now.Ticks);
        }

        public void Something()
        {
            for (var i = 0; i < 10; i++)
                Thread.Sleep(random.Next(i)*10);
        }
    }
}