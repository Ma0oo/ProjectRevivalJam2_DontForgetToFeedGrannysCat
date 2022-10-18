using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    public class CatFactory : MonoBehaviour
    {
        public IReadOnlyCollection<CatUnit> Cats => _cats;
        [SerializeField] private HashSet<CatUnit> _cats = new HashSet<CatUnit>();

        public event Action<CatUnit> Created;

        public CatUnit GetByIndex(int i) 
            => _cats.ToArray()[Mathf.Clamp(i, 0, _cats.Count)];

        public CatUnit Create(CatUnit catUnit, CatPoint point)
        {
            catUnit.gameObject.SetActive(false);
            var r = catUnit.Spawn(point.transform.position, point.transform.rotation);
            catUnit.gameObject.SetActive(true);
            r.gameObject.InjectGO(DI.Instance);
            r.gameObject.SetActive(true);
            _cats.Add(r);
            Created?.Invoke(r);
            return r;
        }
    }
}