using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class RegisterPlayer : RegisterDI
    {
        [SerializeField] private PlayerFactory _playerFactory;

        protected override void Register(DI di) => di.Set(_playerFactory);

        protected override void Unregister(DI di) => di.Remove<PlayerFactory>();
    }
}