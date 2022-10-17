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
        [SerializeField] private Vector3 _upOffset = new Vector3(0, 1.8f,0 );
        [SerializeField] private Vector3 _AddRotator;
        [DiInject] private PlayerFactory _playerFactory;
        

        private void LateUpdate()
        {
            if(!_playerFactory.HasPlayer) return;   
            TarnsformToRotate.LookAt(_playerFactory.GetOrCreate().transform.position+_upOffset);
            TarnsformToRotate.localEulerAngles += _AddRotator;
        }
    }
}