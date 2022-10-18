using System.Collections.Generic;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    public class PropFactory : MonoBehaviour
    {
        public IReadOnlyCollection<Prop> Props => _props;
        [ShowInInspector] private HashSet<Prop> _props = new HashSet<Prop>();

        public Prop Create(Prop prefab, PropPoint point)
        {
            prefab.gameObject.SetActive(false);
            var r = prefab.Spawn(point.transform.position, point.transform.rotation);
            prefab.gameObject.SetActive(true);
            r.gameObject.InjectGO(DI.Instance);
            _props.Add(r);
            r.Props.GetAll<IInitProp>().ForEach(x => x.Init());
            r.gameObject.SetActive(true);
            return r;
        }
    }
}