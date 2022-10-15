using Plugins.MaoUtility.DataManagers;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    [RequireComponent(typeof(RoomPartManager))]
    public class Room : MonoBehaviour
    {
        public IGeterDataManager<IRoomPart> RoomParts=>_roomPartManager;
        [SerializeField] private RoomPartManager _roomPartManager;

        private void OnValidate() => _roomPartManager = GetComponent<RoomPartManager>();
    }
}