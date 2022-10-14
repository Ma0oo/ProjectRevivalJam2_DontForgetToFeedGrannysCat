using System;
using Plugins.MaoUtility.DILocator.Core;

namespace Plugins.MaoUtility.DILocator.Atr
{
    public class DiInject : Attribute
    {
        public object ID { get; private set; }

        public DiInject() => ID = DI.DefaultId;

        public DiInject(object id) => ID = id;
    }
}