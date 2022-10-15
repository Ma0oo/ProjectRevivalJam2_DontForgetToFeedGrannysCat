using Plugins.MaoUtility.DataManagers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerUnit : SerializedMonoBehaviour
    {
        public IGeterDataManager<IPlayerUnityPart> Parts => _parts;
        [SerializeField] private PlayerPartManager _parts;
    }
}