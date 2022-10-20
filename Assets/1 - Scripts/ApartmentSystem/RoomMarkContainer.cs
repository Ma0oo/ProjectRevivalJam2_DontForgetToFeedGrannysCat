using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.ApartmentSystem
{
    public class RoomMarkContainer : MonoBehaviour, IRoomPart
    {
        public IReadOnlyCollection<RoomMark> Marks => _marks;
        [SerializeField] private RoomMark[] _marks;

        public bool Contains(RoomMark mark) => Marks.Contains(mark);
    }
}