using System.Collections.Generic;
using System.Security.AccessControl;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Director;
using NoSystem;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    public class PropPoint : MonoBehaviour, IRoomPart
    {
        public IReadOnlyCollection<PropPointMark> Marks => _marks;
        [SerializeField] private PropPointMark[] _marks;
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position+Vector3.up*0.05f, new Vector3(0.25f, 0.1f, 0.25f));
        }
    }
}