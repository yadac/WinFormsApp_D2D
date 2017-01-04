using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class PredicateComponent : IComponent
    {
        private readonly IPredicate predicate;
        private readonly IComponent decoratedComponent;

        public PredicateComponent(IComponent decoratedComponent, IPredicate predicate)
        {
            this.decoratedComponent = decoratedComponent;
            this.predicate = predicate;
        }
        public void Something()
        {
            if (predicate.Test())
                decoratedComponent.Something();
        }
    }
}
