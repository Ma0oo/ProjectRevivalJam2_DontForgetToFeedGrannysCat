using System;
using System.Collections.Generic;
using NoSystem;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    public class Apartment : MonoBehaviour
    {
        public IReadOnlyCollection<Room> Rooms => _rooms;
        [SerializeField] private Room[] _rooms;

        private void OnValidate() => _rooms = GetComponentsInChildren<Room>();
    }
}