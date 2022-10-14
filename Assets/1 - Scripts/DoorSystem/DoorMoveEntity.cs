using UltEvents;
using UnityEngine;

namespace DoorSystem
{
    public class DoorMoveEntity : MonoBehaviour
    {
        public UltEvent StartMove;
        public UltEvent EndMove;

        public void SetStateMove(bool state)
        {
            if(state) StartMove.Invoke();
            else EndMove.Invoke();
        }
    }
}