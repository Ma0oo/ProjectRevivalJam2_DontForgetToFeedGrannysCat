using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DataGame.Save
{
    public class RegisterSaveData : RegisterDI
    {
        [SerializeField] private SaveDataProvider _saveDataProvider;
        
        protected override void Register(DI di) => di.Set(_saveDataProvider);

        protected override void Unregister(DI di) => di.Remove<SaveDataProvider>();
    }
}