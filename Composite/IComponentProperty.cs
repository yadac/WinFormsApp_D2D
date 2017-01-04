using System;

namespace Composite
{
    public interface IComponentProperty
    {
        // プロパティもインタフェースによる抽象化対象
        string Property { get; set; }

        // イベントもインタフェースによる抽象化対象
        event EventHandler Event;
    }
}