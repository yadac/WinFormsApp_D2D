using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class ComponentDecorator : IComponentProperty
    {
        private readonly IComponentProperty decoratedComponent;

        public ComponentDecorator(IComponentProperty decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public string Property
        {
            get
            {
                // 値を取得したのち、ここで何らかの変更を加えることが可能
                return decoratedComponent.Property;
            }
            set
            {
                // ここでも値を設定する前に何らかの変更を加えることが可能
                decoratedComponent.Property = value;
            }
        }

        public event EventHandler Event
        {
            add
            {
                // イベントハンドラーの登録時に何かを実行することが可能
                decoratedComponent.Event += value;
            }
            remove
            {
                // イベントハンドラーの登録解除時にも何かを実行することが可能
                decoratedComponent.Event -= value;
            }
        }
    }
}
