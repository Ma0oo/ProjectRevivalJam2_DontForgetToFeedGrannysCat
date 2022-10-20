using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ApartmentSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    [DiMark]
    public class PropFactory : MonoBehaviour
    {
        public IReadOnlyCollection<Prop> Props => _props;
        [ShowInInspector] private HashSet<Prop> _props = new HashSet<Prop>();

        [DiInject] private ApartmentFactory _apartmentFactory;

        public Prop CreateInRandomPlaceApp(Prop prefab) 
            => CreateInRandomPoint(prefab, _apartmentFactory.App.GetAllRoomPart<PropPoint>());

        public Prop CreateInRandomPlaceRoom(Prop prefab, Room room) 
            => CreateInRandomPoint(prefab, room.RoomParts.GetAll<PropPoint>());

        public Prop CreateInRandomPoint(Prop prefab, IEnumerable<PropPoint> point)
        {
            var filter = prefab.Parts.Get<PropAllowedMarkPoint>();
            var pointTarget = point.Where(x => filter.ContainsMark(x.Marks)).GetRandom();
            return Create(prefab, pointTarget);
        }
        
        public Prop Create(Prop prefab, PropPoint point)
        {
            prefab.gameObject.SetActive(false);
            var r = prefab.Spawn(point.transform.position, point.transform.rotation);
            prefab.gameObject.SetActive(true);
            r.gameObject.InjectGO(DI.Instance);
            _props.Add(r);
            r.Parts.GetAll<IInitProp>().ForEach(x => x.Init());
            r.gameObject.SetActive(true);
            return r;
        }
    }
}