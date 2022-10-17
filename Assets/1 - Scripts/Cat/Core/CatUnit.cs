using System;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    [RequireComponent(typeof(CatPartManager))]
    public class CatUnit : MonoBehaviour
    {
        public CatPartManager Parts => _parts??=GetComponent<CatPartManager>();
        private CatPartManager _parts;
    }
}