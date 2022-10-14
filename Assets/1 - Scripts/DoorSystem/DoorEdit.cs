using UnityEngine;

namespace DoorSystem
{
    public class DoorEdit : MonoBehaviour
    {
        public Door Door => _door??=GetComponent<Door>();
        private Door _door;
    }
}