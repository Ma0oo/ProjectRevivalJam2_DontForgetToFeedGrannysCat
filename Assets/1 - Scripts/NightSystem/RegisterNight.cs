using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class RegisterNight : RegisterDI
    {
        [SerializeField] private NightProvider _nightProvider;


        protected override void Register(DI di) => di.Set(_nightProvider);

        protected override void Unregister(DI di) => di.Remove<NightProvider>();
    }
}