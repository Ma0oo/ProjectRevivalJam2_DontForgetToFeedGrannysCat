using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Cat.HungerSystem;
using DefaultNamespace.Cat.HungerSystem.Ext.Prop;
using DefaultNamespace.PropSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.Cat
{
    [DiMark]
    public class CatFactory : MonoBehaviour
    {
        public IReadOnlyCollection<CatUnit> Cats => _cats;
        [SerializeField] private HashSet<CatUnit> _cats = new HashSet<CatUnit>();
        [SerializeField] private Prop _bowl;

        public event Action<CatUnit> Created;

        [DiInject] private ApartmentFactory _apartmentFactory;
        [DiInject] private PropFactory _propFactory;

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

            CreateBowl(r);
            return r;
        }

        private void CreateBowl(CatUnit catUnit)
        {
            var points = _apartmentFactory.App.GetAllRoomPart<PropPoint>();
            var propPointFilter = _bowl.Parts.Get<PropAllowedMarkPoint>();
            var point = points.Where(x => propPointFilter.ContainsMark(x.Marks));
            var result = _propFactory.Create(_bowl, point.GetRandom());
            result.Parts.Get<ViewHungerBowl>().Init(catUnit.Parts.Get<CatHunger>());
        }

        private void OnValidate()
        {
            if (_bowl)
            {
                if (_bowl.Parts.Get<ViewHungerBowl>() == null)
                    _bowl = null;
            }
        }
    }
}