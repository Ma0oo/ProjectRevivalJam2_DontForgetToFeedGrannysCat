using System;

namespace DefaultNamespace.ItemSystem
{
    [System.Serializable]
    public abstract class ItemConfig : ICloneable
    {
        public abstract object Clone();
    }
}