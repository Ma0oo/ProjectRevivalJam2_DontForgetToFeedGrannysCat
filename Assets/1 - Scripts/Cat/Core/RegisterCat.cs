using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    public class RegisterCat : RegisterDI
    {
        [SerializeField]private CatFactory _catFactory;
        
        protected override void Register(DI di) => di.Set(_catFactory);

        protected override void Unregister(DI di) => di.Remove<CatFactory>();
    }
}