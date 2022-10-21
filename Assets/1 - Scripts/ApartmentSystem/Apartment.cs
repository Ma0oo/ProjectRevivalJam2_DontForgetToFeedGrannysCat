using System;
using System.Collections.Generic;
using NoSystem;
using Sirenix.Utilities;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    public class Apartment : MonoBehaviour
    {
        public IReadOnlyCollection<Room> Rooms => _rooms;
        [SerializeField] private Room[] _rooms;

        private void OnValidate() => _rooms = GetComponentsInChildren<Room>();

        public T GetRoomPart<T>() where T : class, IRoomPart
        {
            foreach (var room in Rooms)
            {
                var r = room.RoomParts.Get<T>();
                if (r != null) return r;
            }
            return null;
        }
        
        public List<T> GetAllRoomPart<T>() where T : class, IRoomPart
        {
            List<T> reult = new List<T>();
            foreach (var room in Rooms)
            {
                var r = room.RoomParts.GetAll<T>();
                if (r != null) r.ForEach(reult.Add);
            }
            return reult;
        }
    }
}