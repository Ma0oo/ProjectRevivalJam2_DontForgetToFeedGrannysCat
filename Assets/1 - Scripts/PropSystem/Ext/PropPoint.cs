using DefaultNamespace.ApartmentSystem;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    public class PropPoint : MonoBehaviour, IRoomPart
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position+Vector3.up*0.05f, new Vector3(0.25f, 0.1f, 0.25f));
        }
    }
}