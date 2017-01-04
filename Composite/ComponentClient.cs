using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class ComponentClient
    {
        private readonly IComponent component;
        public ComponentClient(IComponent component)
        {
            this.component = component;
            Console.WriteLine("component client constructor");
        }

        public void Run()
        {
            // lazy = 遅延初期化
            // ここ（実行時に）でインスタンス化される
            component.Something();
        }
    }
}
