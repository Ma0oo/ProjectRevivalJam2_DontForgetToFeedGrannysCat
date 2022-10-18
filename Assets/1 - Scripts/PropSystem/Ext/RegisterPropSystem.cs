using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    public class RegisterPropSystem : RegisterDI
    {
        [SerializeField] private PropFactory _propFactory;
         
        protected override void Register(DI di) => di.Set(_propFactory);

        protected override void Unregister(DI di) => di.Remove<PropFactory>();
    }
}