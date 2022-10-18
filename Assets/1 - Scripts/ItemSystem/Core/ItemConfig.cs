using System;

namespace DefaultNamespace.ItemSystem
{
    public abstract class ItemConfig : ICloneable
    {
        public abstract object Clone();
    }
}