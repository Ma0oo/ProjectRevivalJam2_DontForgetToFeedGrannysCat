using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UltEvents;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Implementation.OneceInterect
{
    public class OnceInterectObject : BaseExtInterectObject
    {
        public UltEvent Clicked;

        protected override void OnInterected(InterectActionBase obj)
        {
            TryCast<OnceInterectAction>(obj, x=>Clicked?.Invoke());
        }
    }
}