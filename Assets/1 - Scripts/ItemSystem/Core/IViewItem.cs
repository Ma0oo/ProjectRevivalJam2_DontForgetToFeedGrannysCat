using System;

namespace DefaultNamespace.ItemSystem
{
    public interface IViewItem
    {
        void Init(Item item);
        Item Item { get; }
        event Action<Item> Inited;
    }
}