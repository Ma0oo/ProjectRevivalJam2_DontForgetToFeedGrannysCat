using NoSystem;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DoorSystem
{
    public class RegisterDoor : RegisterDI
    {
        public const string IdFadeScreen = "FadeScreen by door system";

        [SerializeField] private FadeScreen fadeScreen;
        
        protected override void Register(DI di)
        {
            di.Set(fadeScreen, IdFadeScreen);
        }

        protected override void Unregister(DI di)
        {
            di.Remove<FadeScreen>(IdFadeScreen);
        }
    }
}