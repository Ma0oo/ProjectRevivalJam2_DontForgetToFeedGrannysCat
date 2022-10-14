using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DataGame
{
    public class RegisterData : RegisterDI
    {
        [SerializeField] private DataProvider _dataProvider;
        
        protected override void Register(DI di) => di.Set(_dataProvider);

        protected override void Unregister(DI di) => di.Remove<DataProvider>();
    }
}