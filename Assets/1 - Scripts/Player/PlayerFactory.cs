using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        public bool HasPlayer => _player != null;
        
        [SerializeField] private PlayerUnit _playerUnit;
        
        private PlayerUnit _player;

        public PlayerUnit GetOrCreate()
        {
            if (_player) return _player;
            _playerUnit.gameObject.SetActive(false);
            _player = _playerUnit.Spawn();
            _playerUnit.gameObject.SetActive(true);
            _player.gameObject.InjectGO(DI.Instance);
            _player.gameObject.SetActive(true);
            return _player;
        }
    }
}
