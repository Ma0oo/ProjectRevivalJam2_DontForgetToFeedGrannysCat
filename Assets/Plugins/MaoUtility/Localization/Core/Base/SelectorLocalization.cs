using System;

namespace Plugins.MaoUtility.Localization.Core
{
    [System.Serializable]
    public abstract class SelectorLocalization
    {
        public abstract Type GetTypeLocalizator();
    }
}