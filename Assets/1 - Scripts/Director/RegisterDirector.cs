using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.Director
{
    public class RegisterDirector : RegisterDI
    {
        [SerializeField] private DirectorSystem _directorSystem;
        
        protected override void Register(DI di) => di.Set(_directorSystem);

        protected override void Unregister(DI di) => di.Remove<DirectorSystem>();
    }
}