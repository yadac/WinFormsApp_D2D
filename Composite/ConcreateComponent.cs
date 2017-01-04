using System;

namespace Composite
{
    public class ConcreateComponent : IComponent
    {
        public void Something()
        {
            Console.WriteLine("concreate component");
        }
    }
}