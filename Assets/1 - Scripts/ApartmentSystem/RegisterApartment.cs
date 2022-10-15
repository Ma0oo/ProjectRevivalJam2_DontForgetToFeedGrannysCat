using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    public class RegisterApartment : RegisterDI
    {
        [SerializeField]private ApartmentFactory _factory;
        
        protected override void Register(DI di) => di.Set(_factory);

        protected override void Unregister(DI di) => di.Remove<ApartmentFactory>();
    }
}