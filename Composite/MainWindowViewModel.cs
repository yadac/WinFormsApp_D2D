using System;
using System.Threading.Tasks;

namespace Composite
{
    public class MainWindowViewModel : IComponent
    {
        private readonly IComponent component;

        public MainWindowViewModel(IComponent component)
        {
            this.component = component;
        }

        public void Something()
        {
            component.Something();
            for (var i = 0; i < 100; i++)
                Program.logger.LogInfo(i.ToString());
        }
    }

    public class AsyncComponent : IComponent
    {
        private readonly IComponent decoratedComponent;

        public AsyncComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void Something()
        {
            Task.Run((Action) decoratedComponent.Something);
        }
    }

    public class SampleTaskComponent : IComponent
    {

        public void Something()
        {
            for (var i = 0; i < 100; i++)
                Program.logger.LogInfo(i.ToString());
        }
    }
}