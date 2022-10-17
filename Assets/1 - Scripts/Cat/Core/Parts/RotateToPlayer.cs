using DefaultNamespace.Player;
using Plugins.MaoUtility.DILocator.Atr;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    [DiMark]
    public class RotateToPlayer : MonoBehaviour, ICatPart
    {
        private Transform TarnsformToRotate => _tarnsformToRotate ? _tarnsformToRotate : transform;
        [SerializeField] private Transform _tarnsformToRotate;
        [DiInject] private PlayerFactory _playerFactory;

        private void Update() => TarnsformToRotate.LookAt(_playerFactory.GetOrCreate().transform);
    }
}