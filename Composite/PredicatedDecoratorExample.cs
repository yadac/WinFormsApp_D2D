namespace Composite
{
    public class PredicatedDecoratorExample : IComponent
    {
        private readonly IComponent component;

        public PredicatedDecoratorExample(IComponent component)
        {
            this.component = component;
        }

        public void Something()
        {
            component.Something();
        }
    }
}