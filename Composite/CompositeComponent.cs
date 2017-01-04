using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class CompositeComponent : IComponent
    {
        private ICollection<IComponent> children;

        public CompositeComponent()
        {
            children = new List<IComponent>();    
        }

        // 同じ形(interfaceを継承しているから含めることができる
        public void AddComponent(IComponent component)
        {
            children.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            children.Remove(component);
        }

        public void Something()
        {
            foreach (var child in children)
            {
                child.Something();
            }
        }
    }
}
