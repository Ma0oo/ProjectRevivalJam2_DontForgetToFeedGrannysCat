using System;
using System.Collections.Generic;
using DefaultNamespace.ApartmentSystem;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    public class CatPoint : MonoBehaviour, IRoomPart
    {
        public IReadOnlyCollection<CatPointMark> Marks => _marks;
        [SerializeField] private CatPointMark[] _marks;
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawMesh(ConfigGame.Instance.HeadCatModel, transform.position+Vector3.up*0.3f, transform.rotation, Vector3.one);
        }
    }
}