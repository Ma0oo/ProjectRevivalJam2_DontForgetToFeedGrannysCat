using System;
using Plugins.MaoUtility.Localization.Core;

namespace Plugins.MaoUtility.Localization.Implementation.MaoLocal
{
    [System.Serializable]
    public class LocalByMaoConnect : SelectorLocalization
    {
        public override Type GetTypeLocalizator() => typeof(MaoLocalizator);
    }
}