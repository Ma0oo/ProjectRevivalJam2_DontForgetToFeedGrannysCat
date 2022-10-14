using UnityEngine;

namespace Plugins.MaoUtility.Converse.Core.Components
{
    [RequireComponent(typeof(RectTransform))]
    public class UIMark : BaseConverseComponent
    {
        public override string PrefixAlias => "UI";
    }
}