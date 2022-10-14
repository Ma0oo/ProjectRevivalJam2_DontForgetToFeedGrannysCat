using NoSystem;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace ScenesLogic.Menu
{
    public class RegisterFadeScreenBetweenScene : RegisterDI
    {
        public const string FadeScreenBlack = "0h90f3hnv90wb3";
        
        [SerializeField] private FadeScreen _fadeScreenBlack;


        protected override void Register(DI di) => TryRegister(di, FadeScreenBlack, _fadeScreenBlack);

        protected override void Unregister(DI di)
        {
            
        }

        private void TryRegister(DI di, string id, FadeScreen screen)
        {
            if(di.Has<FadeScreen>(id)) return;
            di.Set(screen, id);
            DontDestroyOnLoad(screen.Canvas.gameObject);
        }
    }
}