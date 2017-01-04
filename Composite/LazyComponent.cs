using System;

namespace Composite
{
    public class LazyComponent : IComponent
    {
        private readonly Lazy<IComponent> lazyComponent;

        public LazyComponent(Lazy<IComponent> lazyComponent)
        {
            this.lazyComponent = lazyComponent;
            Console.WriteLine("lazy component client constructor");
        }

        public void Something()
        {
            lazyComponent.Value.Something();
        }
    }
}